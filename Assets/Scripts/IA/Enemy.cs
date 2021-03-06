﻿using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField] protected float baseSpeed;

    [SerializeField] protected int baseDamage;

    [SerializeField] protected EnemyUI enemyUI;

    [SerializeField] protected GameObject unlockableObject;

    protected int currentHealth;

    protected Rigidbody2D rb2d;

    protected Animator animator;

    protected float damageAccumulated = 0;

    public int BaseDamage
    {
        get { return baseDamage; }
    }

    protected void Init()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = health;
        enemyUI.ArrangeHealthSprites(health);
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
        animator.SetBool("isMoving", true);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        for(int i = 0; i < damage; i++)
        {
            enemyUI.SetInactiveHealth(currentHealth + i, health);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        //unlockableObject.SetActive(true);
        Instantiate(unlockableObject, gameObject.transform.position, gameObject.transform.rotation);
        FindObjectOfType<GameManager>().data.bossDatas[0].isDone = true;
    }
}
