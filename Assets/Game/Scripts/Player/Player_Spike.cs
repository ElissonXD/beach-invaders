using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpike : MonoBehaviour
{
    [SerializeField] private float jumpDistance = 3f;
    [SerializeField] private float jumpDuration = 1f;
    [SerializeField] private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    private bool isJumping;
    private bool isFalling;
    private Vector3 startPos;
    private Vector3 jumpPeak;
    private float jumpProgress;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController ??= GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !isJumping)
        {
            isJumping = true;
            startPos = transform.position;
            jumpPeak = startPos + Vector3.up * jumpDistance;
            jumpProgress = 0f;
            playerController.enabled = false;
        }

        if (isJumping)
        {
            jumpProgress += Time.deltaTime / jumpDuration;
            if (jumpProgress < 0.5f)
            {
                float riseT = jumpProgress / 0.5f;
                transform.position = Vector3.Lerp(startPos, jumpPeak, riseT);
            }
            else
            {
                float fallT = (jumpProgress - 0.5f) / 0.5f;
                transform.position = Vector3.Lerp(jumpPeak, startPos, fallT);
                
                if (jumpProgress >= 1f)
                {
                    isJumping = false;
                    playerController.enabled = true;
                    transform.position = startPos;
                }
            }
        }
    }

    private void StartFall()
    {
        isFalling = true;
    }

    private void EndJump()
    {
        isJumping = false;
        playerController.enabled = true;
        transform.position = startPos;
    }
}
