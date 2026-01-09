using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Crab_Movement : MonoBehaviour
{
    public Crab_Settings crab_settings;
    public float speed = 2.0f;
    
    
    void Update()
    {
        if (!crab_settings.isShooting){
            crab_settings.rigibody.linearVelocity = (Vector2.down) * speed;
            
        }
        else
        {
            crab_settings.animator.SetBool("IsMoving", false);
            crab_settings.rigibody.linearVelocity = Vector2.up * 0f;
        }
    }
}
