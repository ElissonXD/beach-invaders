using UnityEngine;

public class Sniper_Shoot : MonoBehaviour
{
    [Header("Aim Shoot Config")]
    [SerializeField] Sniper_Config sniperConfig;
    [SerializeField] AimConfig aimconfig;

    public float shoot_cooldown;
    public float aim_time;
    private float shoot_timer;
    private float aim_timer;
    private bool instatiated = false;
    private AimConfig instance;

    void Start()
    {
        shoot_timer = shoot_cooldown;
        aim_timer = aim_time;
    }

    void Update()
    {
        if (sniperConfig.is_aiming)
        {
            if (shoot_timer > 0f)
            {
                shoot_timer -= Time.deltaTime;
            } else
            {
                if (!instatiated)
                {
                    instance = Instantiate(aimconfig, sniperConfig.playerconfig.transform.position, sniperConfig.playerconfig.transform.rotation);
                    instatiated = true;
                }

                if (aim_timer > 0f)
                {
                    sniperConfig.animator.SetBool("IsAiming", true);
                    aim_timer -= Time.deltaTime;
                    if (aim_timer <= aim_time / 2){
                        instance.animator.SetTrigger("go");
                    }

                } else
                {
                    sniperConfig.animator.SetBool("IsAiming", false);
                    instance.ShootBullet();
                    SoundEffectManager.Play("Bullet");
                    shoot_timer = shoot_cooldown;
                    aim_timer = aim_time;
                    instatiated = false;
                }
            }
        }
    }
}
