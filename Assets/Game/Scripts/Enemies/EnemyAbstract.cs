using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public float Max_Health = 20f;
    public BoxCollider2D box_collider;
    public Rigidbody2D rigibody;
    public Animator animator;
    public WaveSystem waveSystem;

    public int Exp;
}
