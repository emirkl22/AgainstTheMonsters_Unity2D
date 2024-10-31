using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] zombie;
    [SerializeField]
    private GameObject[] groundFloor;
    public int zombieAmount = 0;
    private int maxZombie;
    private GameManager gameManager;
    private LevelManager levelManager;
    private int levelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        StartCoroutine(zombieSpawner());
        maxZombie = levelManager.levelSO[levelManager.currentLevel].zombieAmount;
    }
    // Update is called once per frame
    void Update()
    {
        levelPrefab = levelManager.levelSO[levelManager.currentLevel].levelNum;
        if (gameManager.isLevelChanged)
        {
            Instantiate(groundFloor[levelManager.levelSO[levelManager.currentLevel].levelNum - 1], transform.position, Quaternion.identity);
            gameManager.isLevelChanged = false;
        }
    }
    IEnumerator zombieSpawner()
    {
        yield return new WaitForSeconds(1f);
        while (gameManager.enemyWallHealth > 0 && gameManager.wallHealth > 0)
        {
            float randomX = Random.Range(-2.4f, 2.3f);
            Vector3 posVector = new Vector3(randomX, 2.5f, 0f);
            if (levelManager.currentLevel > 3 && levelManager.currentLevel < 8)
                posVector.y = 1.8f;
            else
                posVector.y = 2.5f;
            int enemyIndex = levelManager.levelSO[levelManager.currentLevel].levelNum - 1;
            Instantiate(zombie[enemyIndex], posVector, Quaternion.Euler(0, 0, -90));
            zombieAmount++;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
