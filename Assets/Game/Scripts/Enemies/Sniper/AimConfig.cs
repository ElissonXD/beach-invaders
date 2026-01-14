using UnityEngine;

public class AimConfig : MonoBehaviour
{
    Player_Config playeconfig;

    public SpriteRenderer aim_sprite;

    public CircleCollider2D aim_collider;
    public Animator animator;
    public float move_cooldown = 0.5f;
    public float acceleration = 0.01f;
    public float max_speed = 5f;
    private bool isMoving = false;
    private float move_timer;
    public float stay_timer = 1f;
    public bool stay = false;

    private float current_speed = 0f;
    void Start()
    {
        playeconfig = GameObject.FindFirstObjectByType<Player_Config>();
        transform.position = playeconfig.transform.position;
        move_timer = move_cooldown;
        aim_collider.enabled = false;
        stay = false;
    }

    void Update()
    {
        if (transform.position == playeconfig.transform.position)
        {
            move_timer = move_cooldown;
            isMoving = false;
        }
        else
        {
            if (move_timer > 0f)
            {
                move_timer -= Time.deltaTime;
                isMoving = false;
            } else
            {
                isMoving = true;
            }
        }

        
        if (stay)
        {
            isMoving = false;
            stay_timer -= Time.deltaTime;
            if (stay_timer <= 0f){
                aim_collider.enabled = true;
                if (stay_timer < -0.5f)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (isMoving)
        {
            current_speed += acceleration;
            if (current_speed > max_speed)
            {
                current_speed = max_speed;
            }
            transform.position = Vector2.MoveTowards(transform.position, playeconfig.transform.position, current_speed);
        } else
        {
            current_speed = 0f;
        }
    }

    public void ShootBullet()
    {
        stay = true;
        animator.SetTrigger("go");
    }
}
