using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float friction = 40f;

    private Vector2 currentVelocity;


    private void Update()
    {
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;

        moveInput.Normalize();

        Vector2 desiredVelocity = moveInput * maxSpeed;

        if (moveInput.magnitude > 0)
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, desiredVelocity, acceleration * Time.deltaTime);
        }
        else
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, friction * Time.deltaTime);
        }

        Vector3 newPos = transform.position + (Vector3)(currentVelocity * Time.deltaTime);
        newPos.x = Mathf.Clamp(newPos.x, -5.29f, 5.28f);
        newPos.y = Mathf.Clamp(newPos.y, -4.02f, -1.98f + 0.4f);

        transform.position = newPos;
    }
}