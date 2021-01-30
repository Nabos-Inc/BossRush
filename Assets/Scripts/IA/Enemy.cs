using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField] protected float baseSpeed;

    [SerializeField] protected int baseDamage;

    protected Rigidbody2D rb2d;

    protected Animator animator;

    protected void Init()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public abstract void Move(Vector3 direction);

    public abstract void Attack();

    protected float GetRawValue(float value)
    {
        if(value > 0) return 1f;
        else if(value < 0) return -1f;
        return 0;
    }

    protected void UpdateAnimation(Vector2 movement)
    {
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }
}
