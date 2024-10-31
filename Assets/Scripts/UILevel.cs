using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using TMPro.EditorUtilities;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    private GameManager gameManager;
    private LevelManager levelManager;
    //ZombieMovement zombieMovement;
    private AudioManager audioManager;
    [SerializeField]
    GameObject levelClear;
    [SerializeField]
    GameObject levelFailed;
    [SerializeField]
    GameObject zombieCoinAdd;

    public bool isZombieDead;
    private float exitTime;
    private bool isClear = true;
    private bool isFailed = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isZombieDead && levelManager.currentLevel == levelManager.maxLevel - 1)
        {
            zombieCoinAdd.SetActive(true);
            exitTime += Time.deltaTime;
            if (exitTime > 0.5f)
            {
                zombieCoinAdd.SetActive(false);
                exitTime = 0;
                isZombieDead = false;
            }
        }
        if (gameManager.enemyWallHealth <= 0)
        {
            isFailed = false;
            if (isClear)
            {
                levelClear.gameObject.SetActive(true);
                audioManager.PlaySFX(audioManager.levelClear);
                if (levelManager.currentLevel == levelManager.maxLevel - 1)
                {
                    gameManager.Coins += levelManager.levelSO[levelManager.currentLevel].coinEarned;
                }
                isClear = false;
            }
        }
        if (gameManager.wallHealth <= 0)
        {
            isClear = false;
            if (isFailed)
            {
                levelFailed.gameObject.SetActive(true);
                audioManager.PlaySFX(audioManager.levelFailed);
            }
            isFailed = false;
        }

    }
}
