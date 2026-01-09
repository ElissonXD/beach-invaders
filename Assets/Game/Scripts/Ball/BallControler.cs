using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    private Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LaunchTowardsMouse();
        }
    }

    public void LaunchTowardsMouse()
    {
        if (Mouse.current == null) return;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - transform.position).normalized;
        
        rb.linearVelocity = direction * speed; 
    }

}