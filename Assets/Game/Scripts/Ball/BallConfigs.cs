using UnityEngine;

public class BallConfigs : MonoBehaviour
{
    public Player_Config playerConfig;
    public float moveSpeed;
    public float damage;

    void Start()
    {
        moveSpeed = 4f;
        damage = 10f;
        
    }

    void Update()
    {
        
        if (playerConfig.current_Health <= 0)
        {
            Destroy(gameObject);

        }
        
    }
}
