using UnityEngine;

public class KnightController : Enemy
{
    void Awake()
    {
        base.Init();
    }

    public override void Move(Vector3 direction)
    {
        direction.Normalize();

        if(Mathf.Abs(direction.y) > 0.001f && Mathf.Abs(direction.x) > 0.001f)
        {
            direction.x = 0f;
        }
        else if(Mathf.Abs(direction.x) > 0.001f)
        {
            direction.y = 0f;
        }

        Vector2 movementVector = new Vector2(GetRawValue(direction.x), GetRawValue(direction.y));

        rb2d.MovePosition(rb2d.position + movementVector * baseSpeed * Time.fixedDeltaTime);
        UpdateAnimation(movementVector);
    }

    public override void Attack()
    {
        animator.SetTrigger("attack");
    }
}
