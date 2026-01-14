using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player_Upgrades : MonoBehaviour
{
    private int upgrade1;
    private int upgrade2;
    private int upgrade3;
    public UpgradeStats[] statsupgrades;
    //placeholder balls stats
    //placeholder other upgrades

    public UpgradeAbstract[] Choose_Options()
    {
        upgrade1 = Random.Range(0, statsupgrades.Length);

        do {
            upgrade2 = Random.Range(0, statsupgrades.Length);
        
        } while (upgrade2 == upgrade1);

        do {
            upgrade3 = Random.Range(0, statsupgrades.Length);
        } while (upgrade3 == upgrade1 || upgrade3 == upgrade2);

        UpgradeStats option1 = statsupgrades[upgrade1];
        UpgradeStats option2 = statsupgrades[upgrade2];
        UpgradeStats option3 = statsupgrades[upgrade3];
        return new UpgradeAbstract[] { option1, option2, option3 };
    }
}