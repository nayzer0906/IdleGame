using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsAmount;
    [SerializeField] private TMP_Text buildingName;
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text nextLevel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text upgradePrice;
    [SerializeField] private Button upgradeBtn;

    private void Awake()
    {
        upgradeBtn.onClick.AddListener(UpgradeBuilding);
        currentLevel.text = "1";
        nextLevel.text = "2";
    }

    public void SetBuildingInfo(string name, int income, int upgradePrice, int upgradeLevel)
    {
        buildingName.text = name;
        this.upgradePrice.text = upgradePrice.ToString();
    }

    private void UpgradeBuilding()
    {
        DecrementCoinsAmount();
    }

    private void UpgradeLevel()
    {
        
    }

    private void DecrementCoinsAmount()
    {
        var _coinsAmount = Convert.ToInt32(coinsAmount.text);
        var _upgradePrice = Convert.ToInt32(upgradePrice.text);
        
        _coinsAmount -= _upgradePrice;
        if (_coinsAmount < 0)
            return;
        
        coinsAmount.text = _coinsAmount.ToString();
        IncreaseProgressBar();
    }

    private void IncreaseProgressBar()
    {
        progressBar.value += 0.1f;
        
        var _currentLevel = Convert.ToInt32(currentLevel.text);
        var _nextLevel = Convert.ToInt32(nextLevel.text);
        
        if (progressBar.value >= progressBar.maxValue)
        {
            _currentLevel++;
            _nextLevel++;
            progressBar.value = progressBar.minValue;
        }

        currentLevel.text = _currentLevel.ToString();
        nextLevel.text = _nextLevel.ToString();
    }
}
