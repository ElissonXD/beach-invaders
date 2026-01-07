using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeAbstract : MonoBehaviour
{
    public Sprite sprite;
    public Player_Config player_Config;
    public string upgradeName;
    public string description;
    public int level;

    public abstract void Effect();

    public void Start()
    {
        player_Config = GameObject.FindFirstObjectByType<Player_Config>();
    }
}
