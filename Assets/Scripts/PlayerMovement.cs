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
    public GameObject projectile;

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

        if (Input.GetButtonUp("Bow")){
            Debug.Log("Shoot");
            ShootArrow();
        }

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

    private void ShootArrow(){
        Vector2 direction = new Vector2(animator.GetFloat("moveX"),animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position + ArrowOffset(), Quaternion.identity).GetComponent<Arrow>();
        arrow.SetUp(direction, ChooseArrowOrientation());
    }

    private Vector3 ArrowOffset(){
        Vector3 offset = new Vector3(0.0f,0.0f,0.0f); 
        if(animator.GetFloat("moveX") != 0){
            offset.y += (float) 0.32;
        }
        return offset;
    }

    Vector3 ChooseArrowOrientation(){
        float angle = Mathf.Atan2(animator.GetFloat("moveY"),animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0,0,angle);
    }

}
