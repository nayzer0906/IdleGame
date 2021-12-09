using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBuilding : Building
{
    private void Awake()
    {
        name = "Blue Building";
        income = 100;
        upgradePrice = 200;
        progressBar = 0;
        currentLevel = 1;
        nextLevel = 2;
    }
}
