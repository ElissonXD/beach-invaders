using UnityEngine;

public class Crab_Settings : EnemyAbstract
{
    public bool isShooting = false;
    private float current_Health = 20f;
    public bool die = false; //placeholder

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
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
            isShooting = true;
        
    }

}
