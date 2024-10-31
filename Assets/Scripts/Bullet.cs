using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform upSide;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance;
    private ZombieMovement zombieMovement;
    private GoblinMovement goblinMovement;
    private ServantMovement servantMovement;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioManager audioManager;
    [SerializeField]
    private GameObject BulletPassBlood;

    private int meatSoundIndex;
    private AudioClip meatSound; 
    // Start is called before the first frame update
    void Start()
    {
        zombieMovement = FindObjectOfType<ZombieMovement>();
        goblinMovement = FindObjectOfType<GoblinMovement>();
        servantMovement = FindObjectOfType<ServantMovement>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        spawnManager = FindObjectOfType<SpawnManager>();

        meatSoundIndex = Random.Range(0,5);
        for(int i = 0; i < 5; i++)
        {
            if(i == meatSoundIndex)
            {
                meatSound = audioManager.meatSounds[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 6)
        {
            transform.position += Vector3.up * Time.deltaTime * speed * 10f;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("zombie"))
        {
            if (collision.gameObject.GetComponent<ZombieMovement>().zombieHealth > 0)
            {
                if (gameManager.equippedBulletLv == 0)
                {
                    collision.gameObject.GetComponent<ZombieMovement>().zombieHealth -= 1;
                    Instantiate(BulletPassBlood, 
                        collision.gameObject.transform.position, 
                        Quaternion.Euler(0, 0, 90));
                    audioManager.PlaySFX(meatSound);

                }
                else
                {
                    collision.gameObject.GetComponent<ZombieMovement>().ZombieTakeDamage();
                    Instantiate(BulletPassBlood, collision.gameObject.transform.position, Quaternion.Euler(0,0,90));
                    audioManager.PlaySFX(meatSound);
                }
            }
            else
            {
                spawnManager.zombieAmount--;
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
                audioManager.PlaySFX(audioManager.enemyWall);
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
                {
                    collision.gameObject.GetComponent<GoblinMovement>().goblinHealth -= 1;
                    Vector3 bloodPos = transform.position;
                    bloodPos.y += 1f; 
                    Instantiate(BulletPassBlood, bloodPos, Quaternion.Euler(0,0,90));
                    audioManager.PlaySFX(meatSound);
                }
                else
                {
                    collision.gameObject.GetComponent<GoblinMovement>().GoblinTakeDamage();
                    Vector3 bloodPoint = collision.gameObject.transform.position;
                    bloodPoint.y += 1f;
                    Instantiate(BulletPassBlood, bloodPoint, Quaternion.Euler(0, 0, 90));
                    audioManager.PlaySFX(meatSound);
                }
            }
            else
            {
                spawnManager.zombieAmount--;
                Destroy(collision.gameObject);

            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("servant"))
        {
            if (collision.gameObject.GetComponent<ServantMovement>().servantHealth > 0)
            {
                if (gameManager.equippedBulletLv == 0)
                {
                    collision.gameObject.GetComponent<ServantMovement>().servantHealth -= 1;
                    audioManager.PlaySFX(meatSound);
                }
                else
                {
                    collision.gameObject.GetComponent<ServantMovement>().ServantTakeDamage();
                    Vector3 bloodPoint2 = collision.gameObject.transform.position;
                    bloodPoint2.y += 0.5f;
                    Instantiate(BulletPassBlood, bloodPoint2, Quaternion.Euler(0, 0, 90));
                    audioManager.PlaySFX(meatSound);
                }
            }
            else
            {
                spawnManager.zombieAmount--;
                Destroy(collision.gameObject);

            }
            Destroy(gameObject);
        }
    }
}
