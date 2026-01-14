using UnityEngine;

public class Crab_Settings : EnemyAbstract
{
    [Header("Player Inputs")]
    public GameObject player;
    public Player_Config playerConfig;
    [Header("Ball Inputs")]
    public BallConfigs ballConfigs;
    public GameObject ball;
    public CircleCollider2D ballCollider;
    public bool isShooting = false;
    private float current_Health = 20f;
    public bool die = false; //placeholder
    public int expAmount = 25;
    void Start()
    {
        animator.SetBool("IsMoving", true);
        playerConfig = player.GetComponent<Player_Config>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
        waveSystem = GameObject.FindAnyObjectByType<WaveSystem>();
    }
    void Update()
    {
        if (current_Health <= 0f || die)
        {
            waveSystem.enemies_killed -= 1;
            Player_Experience.Instance.AddExperience(expAmount);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Net"))
        {
            isShooting = true;
        }

    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            current_Health -= ballConfigs.damage;
        }
    }
}