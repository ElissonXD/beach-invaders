using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveSystem : MonoBehaviour
{
    public Transform[] spawn_points;
    [SerializeField] public EnemyRow[] waves;
    public int current_wave = 0;
    public TMP_Text wave_text;
    public Animator animator;
    public bool spawn_enemy = false;
    private int total_enemies = 3;
    public int enemies_killed = 3;
    private int last_wave = 3;
    public int total_increasse = 1;
    public float force_spawn = 5.0f;
    private float force_spawn_timer = 0f;
    private EnemyAbstract[] current_enemies;
    public int wave_counter = 1;

    void Start()
    {
        wave_text.text = "Wave " + wave_counter.ToString();
        animator.SetTrigger("Show");
        current_enemies = waves[current_wave].enemies;
        spawn_enemy = true;
    }

    void Update()
    {
        if (spawn_enemy){
            if (total_enemies > 0){
                spawn_enemy = false;
                total_enemies -= 1;

                int random = UnityEngine.Random.Range(0, spawn_points.Length);
                Transform pos = spawn_points[random];
                int enemy = UnityEngine.Random.Range(0, current_enemies.Length);
                Instantiate(current_enemies[enemy], pos.position, pos.rotation);
                
                force_spawn_timer = 0;
            }
        }
        else {
            if (force_spawn_timer < force_spawn && total_enemies > 0){
                force_spawn_timer += Time.deltaTime;
                if (force_spawn_timer >= force_spawn)
                {
                    spawn_enemy = true;
                }
            }
        }

        if (enemies_killed <= 0) {
                wave_counter += 1;
                current_wave = Mathf.Min(current_wave+1, waves.Length);
                Start_Wave(current_wave);

        }
    }

    EnemyAbstract[] Start_Wave(int wave)
    {
        wave_text.text = "Wave " + wave_counter.ToString();
        animator.SetTrigger("Show");
        total_enemies = last_wave + total_increasse;
        last_wave = total_enemies;
        enemies_killed = total_enemies;
        return waves[wave].enemies;
    }

}


// Gambiarra
[System.Serializable]
public class EnemyRow {
    public EnemyAbstract[] enemies;
}
