using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingStats : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text nextLevel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text upgradePrice;
    private Building building;
}
