using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float jumpScaleMultiplier = 1.5f;

    [SerializeField] private Vector2 minBounds = new Vector2(-5.29f, -4.02f);
    [SerializeField] private Vector2 maxBounds = new Vector2(5.28f, -1.58f);

    private Rigidbody2D rb;
    private Camera mainCamera;

    public Vector3 originalScale;
    public bool isMoving = false;
    public bool isReturning = false;
    public float movementDuration;
    public float currentTimer;
    public Vector2 targetPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (isMoving)
        {
            currentTimer += Time.deltaTime;

            float progress = currentTimer / movementDuration;

            if (progress >= 1f)
            {
                rb.linearVelocity = Vector2.zero;
                transform.localScale = originalScale;
                isMoving = false;

                if (!isReturning)
                {
                    ReturnToRandomPlayerPosition();
                }
                else
                {
                    StopMovement();
                }
            }
            else
            {
                float arcHeight = Mathf.Sin(progress * Mathf.PI);
                Vector3 newScale = originalScale + (originalScale * jumpScaleMultiplier * arcHeight);
                transform.localScale = newScale;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Mouse.current == null) return;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            MoveToPosition(mouseWorldPos, false);
        }
    }

    public void ReturnToRandomPlayerPosition()
    {
        float targetPosX = Random.Range(minBounds.x, maxBounds.x);
        float targetPosY = Random.Range(minBounds.y, maxBounds.y);
        targetPos = new Vector2(targetPosX, targetPosY);

        MoveToPosition(targetPos, true);
    }

    private void MoveToPosition(Vector2 targetPos, bool returningState)
    {
        Vector2 startPos = transform.position;
        Vector2 direction = (targetPos - startPos).normalized;
        float distance = Vector2.Distance(startPos, targetPos);

        if (distance < 0.1f)
        {
            if (!returningState) ReturnToRandomPlayerPosition();
            else StopMovement();
            return;
        }

        movementDuration = distance / moveSpeed;
        currentTimer = 0f;
        isMoving = true;
        isReturning = returningState;

        rb.linearVelocity = direction * moveSpeed;
    }

    private void StopMovement()
    {
        isMoving = false;
        isReturning = false;
        rb.linearVelocity = Vector2.zero;
        transform.localScale = originalScale;
    }
}