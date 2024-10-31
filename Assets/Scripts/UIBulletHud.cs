using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBulletHud : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    GameObject[] bulletHud;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        for (int x = 0; x < 7; x++)
        {
            if (x == gameManager.equippedBulletLv)
            {
                bulletHud[x].gameObject.SetActive(true);
            }
            else
            {
                bulletHud[x].gameObject.SetActive(false);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isBulletHud)
        {
            for (int y = 0; y < 7; y++)
            {
                if (y == gameManager.equippedBulletLv)
                {
                    bulletHud[y].gameObject.SetActive(true);
                }
                else
                {
                    bulletHud[y].gameObject.SetActive(false);
                }
            }
            gameManager.isBulletHud = false;
        }
    }

 
    public void BulletHudChange(int bulletHudIndex)
    {
        for (int z = 0; z < 7; z++)
        {
            if (z == bulletHudIndex + 1)
            {
                bulletHud[z].gameObject.SetActive(true);
            }
            else
            {
                bulletHud[z].gameObject.SetActive(false);
            }
        }
    }
}
