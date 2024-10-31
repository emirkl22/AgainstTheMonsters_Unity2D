using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private bool isHit = false;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform bottom;
    [SerializeField]
    private GameObject bloodSplatter;
    private GameManager gameManager;
    private LevelManager levelManager;
    private AudioManager audioManager;
    private UILevel uiLevel;
    public int zombieHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
        uiLevel = FindObjectOfType<UILevel>();
        zombieHealth = gameManager.zombieHealth ;
        transform.localScale = new Vector3(gameManager.zombieScale, gameManager.zombieScale, gameManager.zombieScale);
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("isWalk");
        anim.ResetTrigger("isAttack");   
    }
    // Update is called once per frame
    void Update()
    {
        CheckForWall(bottom);
        if (!isHit)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if(zombieHealth <= 0)
        {
            if(levelManager.currentLevel == levelManager.maxLevel - 1)
            {
                gameManager.Coins++;
                audioManager.PlaySFX(audioManager.zombieCoin);
            }
            uiLevel.isZombieDead = true;
            Instantiate(bloodSplatter, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.zombieDeath);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            isHit = true;
            anim.ResetTrigger("isWalk");
        }
    }
    private void CheckForWall(Transform bottom)
    {
        var rayCastHit = Physics2D.Raycast(bottom.position, -bottom.up, maxDistance, layerMask);
        Debug.DrawRay(bottom.position, -bottom.up * maxDistance, Color.red);

        if (rayCastHit && rayCastHit.collider.CompareTag("wall"))
        {
            isHit = true;
            anim.ResetTrigger("isWalk");
            
            if(gameManager.enemyWallHealth <= 0)
            {
                anim.ResetTrigger("isAttack");
            }
            else
            {
                anim.SetTrigger("isAttack");
            }
            
        }
        else if (rayCastHit && !rayCastHit.collider.CompareTag("wall"))
        {
            isHit = false;
            anim.ResetTrigger("isWalk");
        }
        else
        {
            isHit = false;
            anim.SetTrigger("isWalk");
        }
    }

    public void ZombieTakeDamage()
    {
        zombieHealth -= gameManager.currentBulletDamage;
    }
}
