using System;
using UnityEditor;
using UnityEngine;

public class ballDestinationBehavior : MonoBehaviour
{
    public GameObject ball;
    private BallController ballController;
    private float counter = 0;
    [SerializeField] private CircleCollider2D destinationHitBox;
    void Start()
    {
        ballController = ball.GetComponent<BallController>();
        transform.localScale = Vector3.zero;
        destinationHitBox.radius = 0;

    }

    void Update()
    {
        if (ballController.isReturning)
        {
            transform.position = ballController.targetPos;
            targetAnimation();
        
        } 
        
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
            destinationHitBox.radius = 0;
            counter = 0;

        }

    }

    void targetAnimation()
    {
        transform.localScale = new Vector3(0.25f + Mathf.Abs(Mathf.Sin(2 * Mathf.PI * counter)) / 5, 0.25f + Mathf.Abs(Mathf.Sin(2 * Mathf.PI * counter)) / 5, 0.25f + Mathf.Abs(Mathf.Sin(2 * Mathf.PI * counter)) / 5);
        destinationHitBox.radius = 2 + Mathf.Abs(Mathf.Sin(2 * Mathf.PI * counter)) / 5;
        transform.localRotation = Quaternion.Euler(0, 0, counter * 180);

        counter += Time.deltaTime;
    }
}
