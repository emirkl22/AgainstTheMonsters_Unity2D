using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MarketButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private MarketManager marketManager;
    private GameManager gameManager;
    private UIBulletHud uiBulletHub;
    private AudioManager audioManager;
    [SerializeField]
    private int bulletIndex;
    [SerializeField]
    private float bulletInterval;
    [SerializeField]
    private int bulletDamage;
    [SerializeField]
    private int price;
    private int i;
    private float exitTime;
    private bool isCoinNotBought;
    [SerializeField]
    GameObject enoughMoney;
    [SerializeField]
    GameObject notEnoughMoney;
    private int maxEquip;

     

    // Start is called before the first frame update
    void Start()
    {
        marketManager = FindObjectOfType<MarketManager>();
        gameManager = FindObjectOfType<GameManager>();
        uiBulletHub = FindObjectOfType<UIBulletHud>();
        audioManager = FindObjectOfType<AudioManager>();

        buttonText.text = marketManager.StartSwitchButton(marketManager.buttonCounters[bulletIndex]);
        i = marketManager.buttonCounters[bulletIndex];

        
    }
    // Update is called once per frame
    void Update()
    {
        buttonText.text = marketManager.StartSwitchButton(marketManager.buttonCounters[bulletIndex]);
        i = marketManager.buttonCounters[bulletIndex];
        if(i == 2)
        {
            gameManager.equippedBulletLv = bulletIndex + 1;
        }

        if (gameManager.isCoinBought)
        {
            enoughMoney.SetActive(true);
            exitTime += Time.deltaTime;
            if(exitTime > 1)
            {
                enoughMoney.SetActive(false);
                gameManager.isCoinBought = false;
                exitTime = 0;
            }
        }

        if(isCoinNotBought == true)
        {
            notEnoughMoney.SetActive(true);
            exitTime += Time.deltaTime;
            if (exitTime > 1)
            {
                notEnoughMoney.SetActive(false);
                isCoinNotBought = false;
                exitTime = 0;
            }
        }
    }
    public void BuyEquip()
    {
        audioManager.PlaySFX(audioManager.Button);
        if (gameManager.Coins >= price || i > 0)
        {
            if (i == 0)
            {
                gameManager.bulletLv = bulletIndex;
                audioManager.PlaySFX(audioManager.coinAdded);
                gameManager.BuyBullet(price);
            }
            i++;
            if (i == 3)
            {
                i = 1;
            }
            switch (i)
            {
                case 1:
                    buttonText.text = "EQUIP";
                    gameManager.bulletLv = bulletIndex;
                    break;
                case 2:
                    buttonText.text = "EQUIPPED";
                    gameManager.ChangeBullet();
                    marketManager.BulletEquipped(bulletIndex);
                    uiBulletHub.BulletHudChange(bulletIndex);
                    gameManager.currentBulletInterval = bulletInterval;
                    gameManager.currentBulletDamage = bulletDamage;
                    break;
                default:
                    buttonText.text = "BUY";
                    break;
            }
            marketManager.buttonCounters[bulletIndex] = i;
        }
        else if(gameManager.Coins < bulletIndex * 10 + 5 && i == 0)
        {
            isCoinNotBought = true; 
        }
        maxEquip = 0;
        for(int i = 0; i < 6; i++)
        {
            if (marketManager.buttonCounters[i] == 1 || marketManager.buttonCounters[i] == 0)
            {
                maxEquip++;
            }
            if (maxEquip == 6)
            {
                gameManager.equippedBulletLv = 0;
                gameManager.isBulletHud = true;
            }
        }
    }
}
