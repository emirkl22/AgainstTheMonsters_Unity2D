using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //ZombieMovement zombieMovement;
    private LevelManager levelManager;
    public int Coins;

    private int bulletDamage;

    public int levelOrder;
    private int currentSceneIndex;
    

    public int wallHealth;
    public int maxWallHealth;
    public int enemyWallHealth;
    public int maxEnemyWallHealth;
    public int zombieHealth;
    public int maxZombieHealth;
    public int zombieScale;

    public bool isLevelChanged;
    public int bulletLv;
    public int equippedBulletLv;
    public bool isCoinBought;

    public float currentBulletInterval;
    public int currentBulletDamage;
    public bool isJoystickPressed;
    public bool isBulletHud = true;
    public bool isMiddleHit = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        levelManager = FindObjectOfType<LevelManager>();
        Coins = 0;
        levelOrder = 1;
        bulletLv = 0;
        equippedBulletLv = 0;

        wallHealth = levelManager.levelSO[levelManager.currentLevel].wallHealth;
        maxWallHealth = levelManager.levelSO[levelManager.currentLevel].maxWallHealth;
        enemyWallHealth = levelManager.levelSO[levelManager.currentLevel].enemyWallHealth;
        maxEnemyWallHealth = levelManager.levelSO[levelManager.currentLevel].maxEnemyWallHealth;
        zombieHealth = levelManager.levelSO[levelManager.currentLevel].zombieHealth;
        maxZombieHealth = levelManager.levelSO[levelManager.currentLevel].maxZombieHealth;
        zombieScale = levelManager.levelSO[levelManager.currentLevel].zombieScale;

        currentBulletInterval = 0.8f;
        currentBulletDamage = 1;
    }
    private void Update()
    {

    }
    public void GetStats()
    {
        wallHealth = levelManager.levelSO[levelManager.currentLevel].wallHealth;
        maxWallHealth = levelManager.levelSO[levelManager.currentLevel].maxWallHealth;
        enemyWallHealth = levelManager.levelSO[levelManager.currentLevel].enemyWallHealth;
        maxEnemyWallHealth = levelManager.levelSO[levelManager.currentLevel].maxEnemyWallHealth;
        zombieHealth = levelManager.levelSO[levelManager.currentLevel].zombieHealth;
        maxZombieHealth = levelManager.levelSO[levelManager.currentLevel].maxZombieHealth;
        zombieScale = levelManager.levelSO[levelManager.currentLevel].zombieScale;
        bulletDamage = equippedBulletLv;
    }
    public void TakeDamage()
    {
        wallHealth -= levelManager.levelSO[levelManager.currentLevel].zombieDamage;
        isMiddleHit = true;
    }
    public void EnemyTakeDamage()
    {
        bulletDamage = equippedBulletLv;
        if (equippedBulletLv == 0)
            enemyWallHealth -= 1;
        else
        {
            enemyWallHealth -= currentBulletDamage;
        }
    }
    public void BuyBullet(int price)
    {
        Coins -= price;
        isCoinBought = true;
    }
    public void ChangeBullet()
    {
        equippedBulletLv = bulletLv;
    }

}

