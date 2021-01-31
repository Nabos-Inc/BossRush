using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D myRigidbody;

    void Start()
    {
        
    }
    
    public void SetUp(Vector2 velocity, Vector3 direction){
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);

    }

    
     void OnBecameInvisible () {
         Debug.Log("Delete");
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
        }
    }

}
