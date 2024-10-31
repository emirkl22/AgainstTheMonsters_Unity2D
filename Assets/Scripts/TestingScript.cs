using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform upSide;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance;
    ZombieMovement zombieMovement;
    GoblinMovement goblinMovement;
    ServantMovement servantMovement;
    GameManager gameManager;
    AudioManager audioManager;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        zombieMovement = FindObjectOfType<ZombieMovement>();
        goblinMovement = FindObjectOfType<GoblinMovement>();
        servantMovement = FindObjectOfType<ServantMovement>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletRay();

        if (transform.position.y < 6)
        {
            transform.position += Vector3.up * Time.deltaTime * speed * 10f;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void bulletRay()
    {
        var rayCastHit = Physics2D.Raycast(upSide.position, upSide.up, maxDistance, layerMask);
        Debug.DrawRay(upSide.position, upSide.up * maxDistance, Color.red);
        if (rayCastHit && rayCastHit.collider.CompareTag("zombie"))
        {

            if (rayCastHit.collider.GetComponent<ZombieMovement>().zombieHealth > 0)
            {
                rayCastHit.collider.GetComponent<ZombieMovement>().zombieHealth -= 1;
            }
            else
            {
                Destroy(rayCastHit.collider.gameObject);
            }
            Destroy(gameObject);
        }
        else if (rayCastHit && rayCastHit.collider.CompareTag("enemyWall"))
        {
            Debug.Log("rayCastHit and enemyWall");
            if (gameManager.enemyWallHealth > 0)
            {
                gameManager.EnemyTakeDamage();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("zombie"))
        {
            if (collision.gameObject.GetComponent<ZombieMovement>().zombieHealth > 0)
            {
                if (gameManager.equippedBulletLv == 0)
                    collision.gameObject.GetComponent<ZombieMovement>().zombieHealth -= 1;
                else
                {
                    collision.gameObject.GetComponent<ZombieMovement>().zombieHealth -= gameManager.equippedBulletLv;
                }
            }
            else
            {
                audioManager.PlaySFX(audioManager.zombieDeath);
                audioManager.PlaySFX(audioManager.zombieCoin);
                Destroy(collision.gameObject);

            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("enemyWall"))
        {
            Debug.Log("bullet ontrigger enemyWall");
            if (gameManager.enemyWallHealth > 0)
            {
                gameManager.EnemyTakeDamage();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("goblin"))
        {
            if (collision.gameObject.GetComponent<GoblinMovement>().goblinHealth > 0)
            {
                if (gameManager.equippedBulletLv == 0)
                    collision.gameObject.GetComponent<GoblinMovement>().goblinHealth -= 1;
                else
                {
                    collision.gameObject.GetComponent<GoblinMovement>().goblinHealth -= gameManager.equippedBulletLv;
                }
            }
            else
            {
                audioManager.PlaySFX(audioManager.zombieDeath);
                audioManager.PlaySFX(audioManager.zombieCoin);
                Destroy(collision.gameObject);

            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("servant"))
        {
            if (collision.gameObject.GetComponent<ServantMovement>().servantHealth > 0)
            {
                if (gameManager.equippedBulletLv == 0)
                    collision.gameObject.GetComponent<ServantMovement>().servantHealth -= 1;
                else
                {
                    collision.gameObject.GetComponent<ServantMovement>().servantHealth -= gameManager.equippedBulletLv;
                }
            }
            else
            {
                audioManager.PlaySFX(audioManager.zombieDeath);
                audioManager.PlaySFX(audioManager.zombieCoin);
                Destroy(collision.gameObject);

            }
            Destroy(gameObject);
        }
    }
}
