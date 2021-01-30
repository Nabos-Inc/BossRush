using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int baseHealth;

    [SerializeField] int maxHealth;

    [SerializeField] int baseHealing;

    [SerializeField] int baseDamage;

    [SerializeField] PlayerUI playerUI;

    private int currentHealth;

    private int currentDamage;

    void Start()
    {
        currentHealth = baseHealth;
        playerUI.ArrangeHealthSprites(baseHealth);
    }

    public void AcquireHealth()
    {
        baseHealth += 1;
        playerUI.GenerateHealth(baseHealth);
    }

    public void Heal()
    {
        currentHealth += 1;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0) currentHealth = 0;
        
        for(int i = 0; i < damage; i++)
        {
            playerUI.SetInactiveHealth(currentHealth + i, baseHealth);
        }
    }
}
