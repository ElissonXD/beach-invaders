using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float speed = 3.0f;
    public Rigidbody2D rigidbody;
    public Vector2 direction;

    void Start()
    {
        Transform player_pos = GameObject.FindFirstObjectByType<Player_Config>().transform;
        direction = (player_pos.position - transform.position).normalized;
    }

    void Update()
    {
        rigidbody.linearVelocity = direction * speed;
    }

    


}
