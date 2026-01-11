using System.Threading;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float speed = 3.0f;
    public Rigidbody2D rigidbody;
    public Vector2 direction;
    public float timer_to_dissapear = 4.0f;

    void Start()
    {
        Transform player_pos = GameObject.FindFirstObjectByType<Player_Config>().transform;
        direction = (player_pos.position - transform.position).normalized;
    }

    void Update()
    {
        rigidbody.linearVelocity = direction * speed;

        if (timer_to_dissapear > 0f)
        {
            timer_to_dissapear -= Time.deltaTime;
        }

        if (timer_to_dissapear <= 0f)
        {
            Destroy(gameObject);
        }

    }
}
