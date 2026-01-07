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
    public UpgradeStats[] statsupgrades;
    //placeholder balls stats
    //placeholder other upgrades

    public UpgradeAbstract[] Choose_Options()
    {
        UpgradeStats option1 = statsupgrades[0]; //placeholder
        UpgradeStats option2 = statsupgrades[1]; // placeholder
        UpgradeStats option3 = statsupgrades[2]; // placeholderu

        return new UpgradeAbstract[] { option1, option2, option3 };
    }
}