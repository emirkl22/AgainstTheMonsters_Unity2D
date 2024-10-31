using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField]
    private float speed;
    [SerializeField]
    private InputActionReference moveActionToUse;
    [SerializeField]
    private InputActionReference buttonActionToUse;
    private Rigidbody2D rigidBody2D;
    private UICoinsText coinText;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private Transform frontSide;
    private Animator anim;
    private SpawnerPlayer spawnerPlayer;
    private GameManager gameManager;
    private AudioManager audioManager;
    

    private float shootInterval;
    private float shootTimer;
    private float exitTime2;
    private int sceneIndex;
    [SerializeField]
    public bool isInteract;





    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        coinText = GetComponent<UICoinsText>();
        anim = GameObject.FindGameObjectWithTag("soldierLeg").GetComponent<Animator>();
        spawnerPlayer = FindObjectOfType<SpawnerPlayer>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        anim.SetFloat("SoldierWalkFloat", -1);

        
    }

    

    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        float horizontal = moveDirection.x;
        float vertical = moveDirection.y;
        if(sceneIndex == 2)
        {
            vertical = 0;
        }
        Vector3 posVector = new Vector3(horizontal, vertical, 0);
        transform.position += posVector * speed * Time.deltaTime;

        if (horizontal != 0 || vertical != 0)
        {
            exitTime2 += Time.deltaTime;
            if (gameManager.isJoystickPressed && exitTime2 >= 0.5f)
            {
                audioManager.PlaySFX(audioManager.Walking);
                exitTime2 = 0;
            }
           
            anim.SetFloat("SoldierWalkFloat", 1);
            
            if(sceneIndex == 1)
            {
                transform.right = posVector;
                speed = 1.5f;
            }
            else if( sceneIndex == 2)
            {
                speed = 3f;
                shootTimer += Time.deltaTime;
                if (shootTimer >= gameManager.currentBulletInterval)
                {
                    spawnerPlayer.Shoot();
                    shootTimer = 0f;
                }
            }
        }
        else if(horizontal == 0 && vertical == 0 && gameManager.isJoystickPressed && sceneIndex == 2)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= gameManager.currentBulletInterval)
            {
                spawnerPlayer.Shoot();
                shootTimer = 0f;
            }
        }
        else
        {
            audioManager.OffWalk(audioManager.Walking);
            anim.SetFloat("SoldierWalkFloat", -1);
            shootTimer = shootInterval;
        }
        isInteract = CheckForInteract(frontSide);

        
    }
    private bool CheckForInteract(Transform side)
    {
        var rayCastHit = Physics2D.Raycast(side.position, side.forward, maxDistance, layerMask);
        Debug.DrawRay(side.position, side.forward * maxDistance, Color.red);
        if (rayCastHit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeShootSpeed()
    {
        shootInterval =  0.5f / (gameManager.equippedBulletLv + 1f);
    }
}
