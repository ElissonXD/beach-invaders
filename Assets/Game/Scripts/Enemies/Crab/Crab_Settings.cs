using UnityEngine;

public class Crab_Settings : MonoBehaviour
{
    public bool isShooting = false;
    public float Max_Health = 20f;
    public BoxCollider2D box_collider;
    public Rigidbody2D rigibody;
    public Animator animator;
    private float current_Health = 20f;

    void Start()
    {
        animator.SetBool("IsMoving", true);
    }
    void Update()
    {
        if (current_Health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
            isShooting = true;
        
    }

}
