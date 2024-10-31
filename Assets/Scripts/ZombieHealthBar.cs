using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private GameManager gameManager;
    private ZombieMovement zombieMovement;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        zombieMovement = FindObjectOfType<ZombieMovement>();    

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar(zombieMovement.zombieHealth, gameManager.maxZombieHealth);
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
