using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : Singleton<Building>
{
    public string name;
    public int income;
    public int upgradePrice;
    public float progressBar;
    public int currentLevel;
    public int nextLevel;
}