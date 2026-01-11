using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UpgradeMenu : MonoBehaviour
{
    public Player_Upgrades playerUpgrades;
    public Animator animator;

    // Buttons
    public Button option1;
    public Button option2;
    public Button option3;

    // Texts
    public TMP_Text option1Text;
    public TMP_Text option2Text;
    public TMP_Text option3Text;

    public TMP_Text option1desc;
    public TMP_Text option2desc;
    public TMP_Text option3desc;

    public TMP_Text option1lv;
    public TMP_Text option2lv;
    public TMP_Text option3lv;

    // Current Sprite
    public Image currentSprite1;
    public Image currentSprite2;
    public Image currentSprite3;

    private bool button_pressed;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.uKey.wasPressedThisFrame) // placeholder
        {
            UpgradeAbstract[] upgrades = playerUpgrades.Choose_Options();
            SetOptions(upgrades);
            animator.SetTrigger("MoveIn");
        }


    }
    public void LevelUpMenu()
    {
        UpgradeAbstract[] upgrades = playerUpgrades.Choose_Options();
        SetOptions(upgrades);
        animator.SetTrigger("MoveIn");
    }
    void SetOptions(UpgradeAbstract[] options)
    {
        option1.enabled = true;
        option2.enabled = true;
        option3.enabled = true;

        option1Text.text = options[0].upgradeName;
        option2Text.text = options[1].upgradeName;
        option3Text.text = options[2].upgradeName;

        option1lv.text = "Lv. " + options[0].level.ToString();
        option2lv.text = "Lv. " + options[1].level.ToString();
        option3lv.text = "Lv. " + options[2].level.ToString();

        option1desc.text = options[0].description;
        option2desc.text = options[1].description;
        option3desc.text = options[2].description;

        currentSprite1.sprite = options[0].sprite;

        currentSprite2.sprite = options[1].sprite;

        currentSprite3.sprite = options[2].sprite;

        option1.onClick.AddListener(options[0].Effect);
        option2.onClick.AddListener(options[1].Effect);
        option3.onClick.AddListener(options[2].Effect);

    }


    public void goBack()
    {
        animator.SetTrigger("MoveOut");
        option1.enabled = false;
        option2.enabled = false;
        option3.enabled = false;
        
        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();
        option3.onClick.RemoveAllListeners();
    }

}


