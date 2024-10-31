using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntrance : MonoBehaviour
{
    [SerializeField]
    private int levelIndex;
    private LevelManager levelManager;
    private GameManager gameManager;
    private AudioManager audioManager;
    [SerializeField]
    GameObject levelLock;
    private PlayerMovement2 playerMovement;
    private float exitTime;
    [SerializeField]
    GameObject passPrevious;
    private bool notPassedPrevious;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        playerMovement = FindObjectOfType<PlayerMovement2>();
        if(levelManager.maxLevel > levelIndex && levelIndex > 0)
        {
            levelLock.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (levelManager.maxLevel > levelIndex && levelIndex > 0)
        {
            levelLock.gameObject.SetActive(false);
        }

        if(notPassedPrevious == true)
        {
            passPrevious.gameObject.SetActive(true);
            exitTime += Time.deltaTime;
            if(exitTime > 1)
            {
                passPrevious.gameObject.SetActive(false);
                notPassedPrevious = false;
                exitTime = 0;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (levelManager.maxLevel > levelIndex)
        {
            playerMovement.ChangeShootSpeed();
            levelManager.currentLevel = levelIndex;
            gameManager.GetStats();
            gameManager.isLevelChanged = true;
            gameManager.isJoystickPressed = false;
            audioManager.ChangeSceneMusic(2);
            SceneManager.LoadScene(2);
        }
        else
        {
            notPassedPrevious = true;
        }
    }
}
