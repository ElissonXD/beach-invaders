using UnityEngine;

public class Player_Config : MonoBehaviour
{
    public int playerHealth = 100;
    public int current_Health = 100;
    public float playerSpeed = 5.0f;
    public float playerRange = 10.0f;
    public float playerDefense = 1.0f;

    public BoxCollider2D collider2d;
    [SerializeField] public int currentExperience, maxExperience, currentLevel;

    void Start()
    {
        if (Player_Experience.Instance != null)
        {
            Player_Experience.Instance.OnExperienceChange += HandleExperienceChange;
        }
    }
    void Update()
    {
        
    }
    private void OnDisable()
    {
        if (Player_Experience.Instance != null)
        {
            Player_Experience.Instance.OnExperienceChange -= HandleExperienceChange;
        }
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
            current_Health -= 10;
            Destroy(other.gameObject);
        }
    }
}
