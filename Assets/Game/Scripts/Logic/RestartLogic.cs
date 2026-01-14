using TMPro;
using UnityEngine;

public class RestartLogic : MonoBehaviour
{
    public Animator animator;
    public TMP_Text counter_text;
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void UpdateCounterText(int counter)
    {
        MusicManager.PauseBackgroundMusic();
        Time.timeScale = 0f;
        counter_text.text = "Waves survived: " + counter.ToString();
    }
}
