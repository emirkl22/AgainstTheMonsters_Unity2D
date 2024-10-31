using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public static MarketManager Instance { get; private set; }
    [SerializeField]
    public int[] buttonCounters;

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

        for (int i = 0; i < 5; i++)
        {
            buttonCounters[i] = 0;
        }
    }

    void Start()
    {

    }
    void Update()
    {

    }
    public void BulletEquipped(int z)
    {
        for(int i = 0; i < 6; i++)
        {
            if(i != z && buttonCounters[i] == 2 )
            {
                buttonCounters[i] = 1;
            }
        }
    }
    public string StartSwitchButton(int x)
    {
        switch (x)
        {
            case 0:
                return "BUY";

            case 1:
                return "EQUIP";

            case 2:
                return "EQUIPPED";

            default:
                return "BUY";

        }
    }
}

