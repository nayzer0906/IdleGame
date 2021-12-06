﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBuilding : Building
{
    private void Awake()
    {
        name = "Red Building";
        income = 40;
        upgradePrice = 100;
        upgradeLevel = 400;
    }
}
