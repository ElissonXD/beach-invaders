using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Crab_Bubble : MonoBehaviour
{
    public Crab_Settings crab_Settings;
    public Transform bubble_spawn;
    public Bubble bubble;
    public float coodldown = 2.0f;
    private float coodldown_timer = 2.0f;

    void Update()
    {
        if (crab_Settings.isShooting)
        {
            if (coodldown_timer <= coodldown)
            {
                coodldown_timer += Time.deltaTime;
            }
            else
            {
                coodldown_timer = 0f;
                Instantiate(bubble, bubble_spawn.position, bubble_spawn.rotation);
            }
        }
    }
}
