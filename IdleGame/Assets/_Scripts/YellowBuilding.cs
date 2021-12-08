using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBuilding : Building
{
    private void Awake()
    {
        name = "Yellow Building";
        income = 10;
        upgradePrice = 50;
        upgradeLevel = 250;
        progressBar = 0;
        currentLevel = 1;
        nextLevel = 2;
    }
}
