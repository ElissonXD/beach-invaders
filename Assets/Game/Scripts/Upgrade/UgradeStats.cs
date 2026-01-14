
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
            player_Config.current_Health = Mathf.Min(player_Config.playerHealth, player_Config.current_Health + 40);
        }
        else if (type == "Speed")
        {
            level += 1;
            player_Config.player_max_speed += 1;
        }
        else if (type == "Defense")
        {
            level +=1;
            player_Config.playerDefense += 0.1f;
        }
    }

}
