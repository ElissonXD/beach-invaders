using UnityEngine;

public class Player_Config : MonoBehaviour
{
    public int playerHealth = 100;
    public float playerSpeed = 5.0f;
    public float playerRange = 10.0f;
    public float playerDefense = 1.0f;

    public BoxCollider2D collider2d;

    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            playerHealth -= 10;
            Destroy(other.gameObject);
        }
    }
}
