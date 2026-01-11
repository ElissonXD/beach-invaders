using UnityEngine;

public class Player_Config : MonoBehaviour
{
    public int playerHealth = 100;
    public float playerSpeed = 5.0f;
    public float playerRange = 10.0f;
    public float playerDefense = 1.0f;
    public UpgradeMenu upgrademenu;

    public BoxCollider2D collider2d;
    int currentExperience, maxExperience, currentLevel;

    void Update()
    {
        
    }

    private void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        upgrademenu.LevelUpMenu();
        currentExperience = 0;
        maxExperience = Mathf.RoundToInt(maxExperience * 0.5f);
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
