using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoblinHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private GameManager gameManager;
    private GoblinMovement goblinMovement;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        goblinMovement = FindObjectOfType<GoblinMovement>();

    }
    void Update()
    {
        UpdateHealthBar(goblinMovement.goblinHealth,
            gameManager.maxZombieHealth);
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
