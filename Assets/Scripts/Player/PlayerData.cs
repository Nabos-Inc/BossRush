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

    [SerializeField] HealingUI healingUI;

    private int currentHealth;

    private int currentDamage;

    void Start()
    {
        currentHealth = baseHealth;
        playerUI.ArrangeHealthSprites(baseHealth);
        healingUI.ArrangeHealthSprites(baseHealth);
    }

    public void AcquireHealth()
    {
        baseHealth += 1;
        playerUI.GenerateHealth(baseHealth);
    }

    public void Heal()
    {
        currentHealth += 1;
        
        if(currentHealth >= baseHealth) currentHealth = baseHealth;

        healingUI.UseHealOrb();
        playerUI.SetActiveHealth(currentHealth, baseHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0) 
        {
            currentHealth = 0;
            // Game Over
            Time.timeScale = 0;
        }

        for(int i = 0; i < damage; i++)
        {
            playerUI.SetInactiveHealth(currentHealth + i, baseHealth);
        }
    }
}
