using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : Singleton<CoinsManager>
{
    private int coins = 1000;
    [SerializeField] private TMP_Text coinsUI;
    public Action<int> OnCoinsChanged;

    private void Awake()
    {
        DisplayCoinsAmount();
        OnCoinsChanged += SetCoinsAmount;
    }

    private void DisplayCoinsAmount()
    {
        coinsUI.text = coins.ToString();
    }

    private void SetCoinsAmount(int val)
    {
        coins += val;
        DisplayCoinsAmount();
    }

    public int GetCoinsAmount()
    {
        return coins;
    }
}