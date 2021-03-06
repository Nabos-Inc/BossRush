﻿using System.Collections;
using UnityEngine;

public class KnightController : Enemy
{
    void Awake()
    {
        base.Init();
    }

    public override void Move(Vector3 direction)
    {
        //direction.Normalize();

        if(Mathf.Abs(direction.y) > 0.1f && Mathf.Abs(direction.x) > 0.1f)
        {
            direction.x = 0f;
        }
        else if(Mathf.Abs(direction.x) > 0.1f)
        {
            direction.y = 0f;
        }
        else if(Mathf.Abs(direction.y) > 0.1f)
        {
            direction.x = 0f;
        }

        Vector2 movementVector = new Vector2(GetRawValue(direction.x), GetRawValue(direction.y));

        rb2d.MovePosition(rb2d.position + movementVector * baseSpeed * Time.fixedDeltaTime);
        UpdateAnimation(movementVector);
    }

    public override void Attack()
    {
        StartCoroutine(IAttack());
    }

    private IEnumerator IAttack()
    {
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(0.4f);
    }
}
