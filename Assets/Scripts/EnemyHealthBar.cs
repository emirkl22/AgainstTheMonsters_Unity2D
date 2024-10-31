using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    float health; 
    float maxHealth;
    private GameManager gameManager;
    private AudioManager audioManager;
    private LevelManager levelManager;
    private float exitInterval = 1f;
    private float exitTimer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        health = gameManager.enemyWallHealth;
        maxHealth = gameManager.maxEnemyWallHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = gameManager.enemyWallHealth;
        maxHealth = gameManager.maxEnemyWallHealth;
        UpdateHealthBar(health, maxHealth);
        if (gameManager.enemyWallHealth <= 0)
        {
            if(levelManager.currentLevel == levelManager.maxLevel - 1)
            {
                levelManager.maxLevel++;
            }
            exitTimer += Time.deltaTime;
            if (exitTimer > exitInterval)
            {
                gameManager.isBulletHud = true;
                audioManager.ChangeSceneMusic(1);
                SceneManager.LoadScene(1);
            }
        }
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
