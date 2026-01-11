using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    public TMP_Text wave_text;
    public TMP_Text health_text;
    public TMP_Text xp_text;
    public TMP_Text last_upgrade;

    public UnityEngine.UI.Image health;
    public UnityEngine.UI.Image xp;

    public Animator animator;
    public Player_Config player_config;
    public WaveSystem waveSystem;
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            wave_text.alpha = 1;
        }   
        else
        {
            wave_text.alpha = 0;
        }

        wave_text.text = "Wave " + waveSystem.wave_counter.ToString();

        health.fillAmount = (float)player_config.current_Health / player_config.playerHealth;

        xp.fillAmount = (float)player_config.currentExperience / player_config.maxExperience;

        health_text.text = player_config.current_Health.ToString() + "/" + player_config.playerHealth.ToString();

        xp_text.text = player_config.currentExperience.ToString() + "/" + player_config.maxExperience.ToString();

    }


    public void getLastUpgrade(TMP_Text text)
    {
        last_upgrade.text = text.text;
    }
}
