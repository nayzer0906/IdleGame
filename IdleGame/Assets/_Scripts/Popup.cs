using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private TMP_Text buildingName;
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text nextLevel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text upgradePrice;
    [SerializeField] private Button upgradeBtn;
    private Building selectedBuilding;

    private void Awake()
    {
        upgradeBtn.onClick.AddListener(UpgradeBuilding);
    }

    public void SetBuildingInfo(Building building)
    {
        selectedBuilding = building;
        buildingName.text = building.name;
        this.upgradePrice.text = building.upgradePrice.ToString();
        this.progressBar.value = building.progressBar;
        this.currentLevel.text = building.currentLevel.ToString();
        this.nextLevel.text = building.nextLevel.ToString();
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
        if (CoinsManager.Instance.GetCoinsAmount() - selectedBuilding.upgradePrice < 0)
            return;
        
        CoinsManager.Instance.OnCoinsChanged?.Invoke(-selectedBuilding.upgradePrice);
        IncreaseProgressBar();
    }

    private void IncreaseProgressBar()
    {
        selectedBuilding.progressBar += 0.1f;
        progressBar.value += 0.1f;

        if (progressBar.value >= progressBar.maxValue)
        {
            selectedBuilding.currentLevel++;
            selectedBuilding.nextLevel++;
            selectedBuilding.upgradePrice *= 2;
            
            progressBar.value = progressBar.minValue;
            selectedBuilding.progressBar = progressBar.minValue;
        }

        currentLevel.text = selectedBuilding.currentLevel.ToString();
        nextLevel.text = selectedBuilding.nextLevel.ToString();
        upgradePrice.text = selectedBuilding.upgradePrice.ToString();
    }
}
