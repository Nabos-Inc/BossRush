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
    private bool usingSword;



    public GameObject projectile;

    private bool hasShield;
    private bool hasSword;
    private bool hasLightArrows;


    public float shootingCooldown;

    public float doubleSlashTimer;
    private float doubleSlashCount;
    private float shootingCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        usingBow = false;
        
        shootingCount = shootingCooldown + 1.0f;
        doubleSlashCount = doubleSlashTimer + 1.0f;
    }

    void initializeEquipment(){
        hasLightArrows = false;
        hasShield = false;
        hasSword = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        usingBow = Input.GetButton("Bow");
        // usingSword = Input.GetButton("Sword");

        UpdateMovementAnimation();

        shootingCount += Time.time;

        if (Input.GetButtonUp("Bow") && (shootingCount > shootingCooldown)){
            Debug.Log("Shoot");
            Debug.Log(shootingCount);

            ShootArrow();
            shootingCount = 0.0f;
            
        } 

        if (Input.GetButtonUp("Sword") && (shootingCount > shootingCooldown)){
            Debug.Log("Slash");
            Debug.Log(shootingCount);

            // Slash();
            shootingCount = 0.0f;
            doubleSlashCount = 0.0f;
        }

        if (doubleSlashCount > doubleSlashTimer) {

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

    void FixedUpdate()
    {
        Movecharacter();
    }

    void UpdateMovementAnimation(){

        if (shootingCount > shootingCooldown){
            // if (usingBow) {
                animator.SetBool("usingBow", usingBow);
                // usingBow = false;
            // }
            // if (usingSword) {
                // animator.SetBool("usingSword", usingSword);
                // usingSword = false;
            // }
        }
        if (change != Vector3.zero){
            //Movecharacter();
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

    // private void Slash(){

    // }

    private void ShootArrow(){
        Vector2 direction = new Vector2(animator.GetFloat("moveX"),animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position + ArrowOffset(), Quaternion.identity).GetComponent<Arrow>();
        arrow.SetUp(direction, ChooseArrowOrientation());
        if(animator.GetFloat("moveY") == -1){
            SpriteRenderer sprite = arrow.GetComponent<SpriteRenderer>();
            Debug.Log(sprite.sortingLayerName.ToString());
            sprite.sortingLayerName = "Projectiles Front";
            Debug.Log(sprite.sortingLayerName.ToString());
        }

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

    public void unlockItem(string name){
        Debug.Log("Unlocked the item" + name);
        if (name == "Sword"){
            hasSword = true;
            animator.SetBool("hasSword", true);
            Debug.Log(hasSword);
        }
        if (name == "Shield"){
            hasShield = true;
            animator.SetBool("hasShield", true);
            // Debug.Log(hasSword);
        }
    }

}
