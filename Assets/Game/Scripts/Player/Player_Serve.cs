using System.Net.Http.Headers;
using UnityEngine;

public class Player_Serve : MonoBehaviour
{
    [Header("Ball inputs")]
    [SerializeField] private GameObject ball;
    [SerializeField] private BallController ballController;
    [SerializeField] private CircleCollider2D ballCollider;

    [Header("Player inputs")]
    [SerializeField] private PlayerSpike playerSpike;
    [SerializeField] private BoxCollider2D playerCollider;

    [Header("Movement Smoothness")]
    [SerializeField] private float moveSpeed = 2f;

    private bool ballPrepared;
    public bool animationOnGoing;
    private bool waited;
    private bool hasExecuted;

    private float timer;
    private const float delay = 0.1f; 

    private Vector3 initialPosition;

    void Start()
    {
        ballPrepared = false;
        waited = false;
        hasExecuted = false;
        animationOnGoing = false;
        
        timer = 0;
        
        ballController = ball.GetComponent<BallController>();
        playerSpike = GetComponent<PlayerSpike>();
    }

    private void wait()
    {
        timer += Time.deltaTime;
        waited = (timer >= delay) ? true : false;
        if (waited) timer = 0;

    }

    private void serve()
    {
        if (!ballController.isMoving && !ballController.isReturning)
        {
            if (!waited) wait();

            else if (!ballPrepared)
            {
                
                if (!hasExecuted)
                {
                    hasExecuted = true;
                    initialPosition = transform.position;

                }
                
                servePreparation();

            }

            else if (playerSpike.isJumping)
            {
                waited = false;
                ball.transform.position = transform.position;
                ball.SetActive(true);
                timer = 0;
                ballPrepared = false;

            }

        }

        else
        {
            hasExecuted = false;
            
        }

    }

    private float evaluate(float x) { return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f; }

    private void servePreparation()
    {
        if (!playerCollider.IsTouching(ballCollider) && !ballController.isMoving && !ballController.isReturning )
        {
            animationOnGoing = true;
            timer += Time.deltaTime * moveSpeed;
            timer = Mathf.Clamp(timer, 0, Mathf.PI);
            float t = evaluate(timer);
            transform.position = Vector3.Lerp(initialPosition, ball.transform.position, t);

        }

        else
        {
            animationOnGoing = false;
            ball.SetActive(false);
            ballPrepared = true;
            timer = 0;
            
        }
    }

    void Update()
    {
        serve();

    }
}
