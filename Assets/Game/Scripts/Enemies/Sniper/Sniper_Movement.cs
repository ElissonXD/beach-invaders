using UnityEngine;

public class Sniper_Movement : MonoBehaviour
{
    [Header("Sniper Movement Config")]
    public float move_speed;
    [SerializeField] Sniper_Config sniperConfig;
    void Update()
    {
        if (!sniperConfig.is_aiming)
        {
            sniperConfig.rigidbody.linearVelocity = Vector2.down * move_speed;
            sniperConfig.animator.SetBool("IsMoving", true);
        } else
        {
            sniperConfig.rigibody.linearVelocity = Vector2.zero;
            sniperConfig.animator.SetBool("IsMoving", false);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sand"))
        {
            sniperConfig.is_aiming = true;
        }    
    }
}
