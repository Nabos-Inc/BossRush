using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField] protected float baseSpeed;

    [SerializeField] protected int baseDamage;

    protected Rigidbody2D rb2d;

    public void Init()
    {
        rb2d =  GetComponent<Rigidbody2D>();
    }

    public abstract void Move(Vector3 direction);

    public abstract void Attack();
}
