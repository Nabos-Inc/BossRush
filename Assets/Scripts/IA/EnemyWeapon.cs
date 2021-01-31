using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    Enemy parent;

    void Awake()
    {
        parent = transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Damage!");
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerData>().TakeDamage(parent.BaseDamage);
        }
    }
}
