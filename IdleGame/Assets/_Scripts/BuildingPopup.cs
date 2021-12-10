using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPopup : Singleton<BuildingPopup>
{
    [SerializeField] private TMP_Text buildingNameUI;
    [SerializeField] private TMP_Text currentLevelUI;
    [SerializeField] private TMP_Text nextLevelUI;
    [SerializeField] private Slider progressBarUI;
    [SerializeField] private TMP_Text upgradePriceUI;
    [SerializeField] private Button upgradeButtonUI;
    private Building selectedBuilding;

    private void Awake()
    {
        upgradeButtonUI.onClick.AddListener(UpgradeBuilding);
    }

    public void DisplayBuildingInfo(Building building)
    {
        selectedBuilding = building;
        buildingNameUI.text = building.name;
        upgradePriceUI.text = building.upgradePrice.ToString();
        progressBarUI.value = building.progressBar;
        currentLevelUI.text = building.currentLevel.ToString();
        nextLevelUI.text = building.nextLevel.ToString();
    }

    private void UpgradeBuilding()
    {
        DecrementCoinsAmount();
    }


    private void DecrementCoinsAmount()
    {
        if (CoinsManager.Instance.GetCoinsAmount() - selectedBuilding.upgradePrice < 0)
            return;
        
        CoinsManager.Instance.OnCoinsChanged?.Invoke(-selectedBuilding.upgradePrice);
        IncreaseProgressBar();
    }

    private void IncreaseProgressBar()
    {
        progressBarUI.value += 0.2f;
        selectedBuilding.progressBar += progressBarUI.value;    

        if (progressBarUI.value >= progressBarUI.maxValue)
        {          
            UpgradeLevel(ref selectedBuilding.currentLevel, ref selectedBuilding.nextLevel);           
            IncreasePrice(ref selectedBuilding.upgradePrice);                      
            ResetProgressBar(progressBarUI);

            selectedBuilding.progressBar = progressBarUI.value;
        }

        ConvertToUI(selectedBuilding.currentLevel, currentLevelUI);
        ConvertToUI(selectedBuilding.nextLevel, nextLevelUI);
        ConvertToUI(selectedBuilding.upgradePrice, upgradePriceUI);
    }

    private void UpgradeLevel(ref int currentLevel, ref int nextLevel)
    {
        currentLevel++;
        nextLevel++;
        IncreaseIncome(ref selectedBuilding.income);
    }

    private void IncreasePrice(ref int price)
    {
        price *= 2;
    }

    private void ResetProgressBar(Slider progressBar)
    {
        progressBar.value = progressBar.minValue;
    }

    private void ConvertToUI(int number, TMP_Text text)
    {
        text.text = number.ToString();            
    }

    private void IncreaseIncome(ref int income)
    {
        income *= 2;
    }
}
