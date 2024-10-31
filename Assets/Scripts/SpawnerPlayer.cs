using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField]
    public bool isBulletGoes;
    private bool bulletBoolean;
    [SerializeField]
    private GameObject[] bulletPrefab;
    [SerializeField]
    private Transform bulletTransform;
    GameManager gameManager;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab[gameManager.equippedBulletLv], 
            bulletTransform.position, Quaternion.identity);
        int index = gameManager.equippedBulletLv;
        audioManager.PlaySFX(audioManager.Shoots[index]);
    }        
            
}
