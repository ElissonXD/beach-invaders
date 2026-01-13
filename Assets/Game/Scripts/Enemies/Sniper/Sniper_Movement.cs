using System;
using UnityEditor.Callbacks;
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
        } else
        {
            sniperConfig.rigibody.linearVelocity = Vector2.zero;
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
