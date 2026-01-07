using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UpgradeStats : UpgradeAbstract
{
    public string type;

    public override void Effect()
    {
        if (type == "Health")
        {
            level  += 1;
            player_Config.playerHealth += 20;
        }
        else if (type == "Range")
        {
            level += 1;
            player_Config.playerRange += 1;
        }
        else if (type == "Defense")
        {
            level +=1;
            player_Config.playerDefense += 0.1f;
        }
    }

}
