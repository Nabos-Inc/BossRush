using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private bool usingBow;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        usingBow = false;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        usingBow = Input.GetButton("Jump");

        UpdateMovementAnimation();
        // if (change != Vector3.zero){
        //     Movecharacter();
        //     animator.SetFloat("moveX", change.x);
        //     animator.SetFloat("moveY", change.y);
        //     animator.SetBool("isMoving", true);

        // } else {
        //     animator.SetBool("isMoving", false);
        // }

        // Debug.Log(change);   
    }

    void UpdateMovementAnimation(){


        animator.SetBool("usingBow", usingBow);
        if (change != Vector3.zero){
            Movecharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);

        } else {
            animator.SetBool("isMoving", false);
        }

    }

    void Movecharacter(){
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );

    }

}
