using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ServantHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private GameManager gameManager;
    private ServantMovement servantMovement;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        servantMovement = FindObjectOfType<ServantMovement>();

    }

    void Update()
    {
        UpdateHealthBar(servantMovement.servantHealth,
            gameManager.maxZombieHealth);
    }
    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
