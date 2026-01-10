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
    private bool firstIteration;

    private float timer;

    private Vector3 initialPosition;

    void Start()
    {
        ballPrepared = false;
        firstIteration = true;
        
        timer = 0;
        
        ballController = ball.GetComponent<BallController>();
        playerSpike = GetComponent<PlayerSpike>();
    }

    private void serve()
    {
        if (!ballController.isMoving && !ballController.isReturning)
        {
            if (!ballPrepared)
            {
                
                if (firstIteration)
                {
                    firstIteration = false;
                    initialPosition = transform.position;

                }
                
                servePreparation();

            }

            else if (playerSpike.isJumping)
            {
                ball.SetActive(true);
                ball.transform.position = transform.position;
                timer = 0;
                ballPrepared = false;
                firstIteration = true;

            }

        }

    }

    private float evaluate(float x) { return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f; }

    private void servePreparation()
    {
        if (!playerCollider.IsTouching(ballCollider))
        {
            timer += Time.deltaTime * moveSpeed;
            timer = Mathf.Clamp(timer, 0, Mathf.PI);
            float t = evaluate(timer);
            transform.position = Vector3.Lerp(initialPosition, ball.transform.position, t);

        }

        else
        {
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
