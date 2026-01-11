using UnityEngine;

public class Player_Experience : MonoBehaviour
{
    public static Player_Experience Instance;

    public delegate void ExperienceChange(int amount);
    public event ExperienceChange OnExperienceChange;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}
