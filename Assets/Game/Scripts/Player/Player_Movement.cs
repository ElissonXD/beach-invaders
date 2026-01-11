using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;

        moveInput.Normalize();

        Vector3 newPos = transform.position + (Vector3)(moveInput * moveSpeed * Time.deltaTime);
        newPos.x = Mathf.Clamp(newPos.x, -5.29f, 5.28f);
        newPos.y = Mathf.Clamp(newPos.y, -4.02f, -1.98f + 0.4f);
        transform.position = newPos;
    }
}
