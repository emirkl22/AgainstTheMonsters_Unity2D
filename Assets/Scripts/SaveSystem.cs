using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    LevelManager levelManager;
    GameManager gameManager;
    MarketManager marketManager;
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
        gameManager = FindObjectOfType<GameManager>();
        marketManager = FindObjectOfType<MarketManager>();
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("MaxLevel", 0) > 1)
        {
            LoadPrefs();
        }
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SavePrefs();
        }
    }
    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins", gameManager.Coins);
        PlayerPrefs.SetInt("EquippedBulletLv", gameManager.equippedBulletLv);
        PlayerPrefs.SetFloat("EquippedBulletInterval", gameManager.currentBulletInterval);
        PlayerPrefs.SetInt("EquippedBulletDamage", gameManager.currentBulletDamage);
        PlayerPrefs.SetInt("MaxLevel", levelManager.maxLevel);
        PlayerPrefs.SetInt("MarketCounters0", marketManager.buttonCounters[0]);
        PlayerPrefs.SetInt("MarketCounters1", marketManager.buttonCounters[1]);
        PlayerPrefs.SetInt("MarketCounters2", marketManager.buttonCounters[2]);
        PlayerPrefs.SetInt("MarketCounters3", marketManager.buttonCounters[3]);
        PlayerPrefs.SetInt("MarketCounters4", marketManager.buttonCounters[4]);
        PlayerPrefs.SetInt("MarketCounters5", marketManager.buttonCounters[5]);
        PlayerPrefs.Save();
    }
    public void LoadPrefs()
    {
        gameManager.Coins = PlayerPrefs.GetInt("Coins", 0);
        gameManager.equippedBulletLv = PlayerPrefs.GetInt("EquippedBulletLv", 0);
        gameManager.currentBulletInterval = PlayerPrefs.GetFloat("EquippedBulletInterval", 0);
        gameManager.currentBulletDamage = PlayerPrefs.GetInt("EquippedBulletDamage", 0);
        levelManager.maxLevel = PlayerPrefs.GetInt("MaxLevel", 1);
        marketManager.buttonCounters[0] = PlayerPrefs.GetInt("MarketCounters0", 0);
        marketManager.buttonCounters[1] = PlayerPrefs.GetInt("MarketCounters1", 0);
        marketManager.buttonCounters[2] = PlayerPrefs.GetInt("MarketCounters2", 0);
        marketManager.buttonCounters[3] = PlayerPrefs.GetInt("MarketCounters3", 0);
        marketManager.buttonCounters[4] = PlayerPrefs.GetInt("MarketCounters4", 0);
        marketManager.buttonCounters[5] = PlayerPrefs.GetInt("MarketCounters5", 0);
    }
}
