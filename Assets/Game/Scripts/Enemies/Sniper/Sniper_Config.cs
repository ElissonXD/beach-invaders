using Unity.VisualScripting;
using UnityEngine;

public class Sniper_Config : EnemyAbstract
{


    [Header("Sniper Config")]
    private float current_health;

    public bool is_aiming = false;
    public int expAmount = 50;
    public Player_Config playerconfig;
    public Rigidbody2D rigidbody;
    

    [Header("Debug")]
    public bool die = false;

    void Start()
    {
        playerconfig = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Config>();
        waveSystem = GameObject.FindFirstObjectByType<WaveSystem>();
        current_health = Max_Health;
    }

    void Update()
    {
        if (current_health <= 0f || die)
        {
            waveSystem.enemies_killed -= 1;
            Player_Experience.Instance.AddExperience(expAmount);
            Destroy(gameObject);
        }
    }
}
