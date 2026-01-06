using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player_Upgrades : MonoBehaviour
{

    // algum objeto relacionado ao controle de ondas totais
    Player_Config playerConfig;
    private string[] upgradesBall = {"Damage", "Speed", "Size"};
    private string[] upgradesPlayer = {"Health", "Range", "Defense"};
    private string[] upgradesSpecial = {"Arena_Change", "Turret"};

    private int[] currentlevelBall = {0, 0, 0};
    private int[] currentlevelPlayer = {0, 0, 0};
    private int[] currentlevelSpecial = {0, 0}; 

    public string[] Choose_Options()
    {
        int index_ball = Random.Range(0, 2);
        int index_player = Random.Range(0, 2);
        int index_special = Random.Range(0, 1);

        return new string[] {
            upgradesBall[index_ball],
            upgradesPlayer[index_player],
            upgradesSpecial[index_special]
        };

    }

    public void Upgrade_Health()
    {
        playerConfig.playerHealth += 20;
        currentlevelPlayer[0] += 1;
    }

    public void Upgrade_Range()
    {
        playerConfig.playerRange += 1.0f;
        currentlevelPlayer[1] += 1;
    }

    public void Upgrade_Defense()
    {
        playerConfig.playerDefense += 0.1f;
        currentlevelPlayer[2] += 1;
    }


}
