using UnityEngine;

public class Crab_Settings : EnemyAbstract
{
    public bool isShooting = false;
    private float current_Health = 20f;
    public bool die = false; //placeholder
    int expAmount = 25;
    void Start()
    {
        animator.SetBool("IsMoving", true);
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

}