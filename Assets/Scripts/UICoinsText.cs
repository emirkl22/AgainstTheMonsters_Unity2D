using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro.EditorUtilities;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    TextMeshProUGUI tmproText;
    private GameManager gameManager;
    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();  
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            tmproText.text = gameManager.Coins.ToString();
        }
    }
}
