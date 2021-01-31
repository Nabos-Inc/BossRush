using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public GameObject dialogBox;
    public string unlockableName; 
    

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Unlocked item!");
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            dialogBox.SetActive(true);
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.unlockItem(unlockableName);

        }

    }
}
