using UnityEngine;

public class Player_Config : MonoBehaviour
{
    public int playerHealth = 100;
    public float playerSpeed = 5.0f;
    public float playerRange = 10.0f;
    public float playerDefense = 1.0f;

    public BoxCollider2D collider2d;
    [SerializeField] int currentExperience, maxExperience, currentLevel;

    void Update()
    {
        
    }
    private void OnEnable()
    {
        Player_Experience.Instance.OnExperienceChange += HandleExperienceChange;
    }
    private void OnDisable()
    {
        Player_Experience.Instance.OnExperienceChange -= HandleExperienceChange;
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
        UpgradeMenu.Instance.LevelUpMenu();
        currentExperience = 0;
        maxExperience = Mathf.RoundToInt(maxExperience * 1.5f);
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
