using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : Enemy
{
    void Awake()
    {
        base.Init();
    }

    public override void Move(Vector3 direction)
    {
        rb2d.MovePosition(transform.position + direction * baseSpeed * Time.deltaTime);
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
