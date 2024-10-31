using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;  

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject mainCamera;
    float health;
    float maxHealth;
    private float exitInterval = 1f;
    private float exitTimer;
    private GameManager gameManager;
    private AudioManager audioManager;
    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = gameManager.wallHealth;
        maxHealth = gameManager.maxWallHealth;
    }
    // Update is called once per frame
    void Update()
    {
        health = gameManager.wallHealth;
        maxHealth = gameManager.maxWallHealth;
        UpdateHealthBar(health, maxHealth); 
        if(gameManager.wallHealth <= 0)
        {
            exitTimer += Time.deltaTime;
            if (exitTimer > exitInterval)
            {
                gameManager.isBulletHud = true;
                audioManager.ChangeSceneMusic(1);
                SceneManager.LoadScene(1);
            }
        }
        if (gameManager.isMiddleHit)
        {
            gameManager.isMiddleHit = false;
            mainCamera.transform.DOShakePosition(0.2f, 0.1f, 5, 90, false, true);
        }
    }
    

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
