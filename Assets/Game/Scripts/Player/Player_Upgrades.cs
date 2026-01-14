using UnityEngine;
using Random = UnityEngine.Random;

public class Player_Upgrades : MonoBehaviour
{
    public UpgradeStats[] statsupgrades;
    //placeholder balls stats
    //placeholder other upgrades

    public UpgradeAbstract[] Choose_Options()
    {
        int rand1 = Random.Range(0, statsupgrades.Length);
        int rand2 = Random.Range(0, statsupgrades.Length);
        while (rand2 == rand1)
        {
            rand2 = Random.Range(0, statsupgrades.Length);
        }
        int rand3 = Random.Range(0, statsupgrades.Length);
        while (rand3 == rand1 || rand3 == rand2)
        {
            rand3 = Random.Range(0, statsupgrades.Length);
        }
        UpgradeStats option1 = statsupgrades[rand1]; 
        UpgradeStats option2 = statsupgrades[rand2]; 
        UpgradeStats option3 = statsupgrades[rand3]; 
        return new UpgradeAbstract[] { option1, option2, option3 };
    }
}