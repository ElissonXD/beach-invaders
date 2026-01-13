using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpScaleMultiplier = 1.5f;

    [Header("Boundaries")]
    [SerializeField] private Vector2 minCourtBounds = new Vector2(-5.29f, -4.02f);
    [SerializeField] private Vector2 maxCourtBounds = new Vector2(5.28f, -1.58f);

    [SerializeField] private Vector2 minScreenBounds = new Vector2(-6f, -5f);
    [SerializeField] private Vector2 maxScreenBounds = new Vector2(6f, 5f);

    [Header("Target Components")]
    public CircleCollider2D targetCollider;
    public GameObject target;

    [Header("Player Components")]
    public GameObject player;
    private PlayerSpike playerScript;
    [Header("Ball Component")]
    public Rigidbody2D rigidBody;

    private Camera mainCamera;

    public Vector3 originalScale;
    public bool isMoving = false;
    public bool isReturning = false;
    public float movementDuration;
    public float currentTimer;
    private float progress;

    private Vector2 startPos;
    public Vector2 targetPos;

    private void Awake()
    {
        mainCamera = Camera.main;
        originalScale = transform.localScale;
        playerScript = player.GetComponent<PlayerSpike>();

    }

    private void Update()
    {
        if (isMoving)
        {
            currentTimer += Time.deltaTime;

            progress = currentTimer / movementDuration;

            if (progress >= 1f)
            {
                transform.position = targetPos;
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
                transform.position = Vector2.Lerp(startPos, targetPos, progress);

                float arcHeight = Mathf.Sin(progress * Mathf.PI);
                Vector3 newScale = originalScale + (originalScale * jumpScaleMultiplier * arcHeight);
                transform.localScale = newScale;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (!isMoving || Vector3.Distance(transform.position, target.transform.position) < targetCollider.radius + 1) && playerScript.isJumping)
        {
            if (Mouse.current == null) return;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            MoveToPosition(mouseWorldPos, false);
        }

        else if (collision.gameObject.CompareTag("Enemy") && !isReturning)
        {
            isMoving = false;
            isReturning = true;
            ReturnToRandomPlayerPosition();

        }
    }

    public void ReturnToRandomPlayerPosition()
    {
        float targetPosX = Random.Range(minCourtBounds.x, maxCourtBounds.x);
        float targetPosY = Random.Range(minCourtBounds.y, maxCourtBounds.y);
        Vector2 randomTarget = new Vector2(targetPosX, targetPosY);

        MoveToPosition(randomTarget, true);
    }

    private void MoveToPosition(Vector2 newTargetPos, bool returningState)
    {
        newTargetPos.x = (newTargetPos.x >= maxScreenBounds.x) ? maxScreenBounds.x : newTargetPos.x;
        newTargetPos.x = (newTargetPos.x < minScreenBounds.x) ? minScreenBounds.x : newTargetPos.x;

        newTargetPos.y = (newTargetPos.y >= maxScreenBounds.y) ? maxScreenBounds.y : newTargetPos.y;
        newTargetPos.y = (newTargetPos.y < minScreenBounds.y) ? minScreenBounds.y : newTargetPos.y;

        startPos = transform.position;
        targetPos = newTargetPos;

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

    }

    private void StopMovement()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        isMoving = false;
        isReturning = false;
        transform.localScale = originalScale;
    }
}