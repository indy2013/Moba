using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;


    public healthbar healthbar;


    void Start()
    {
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage) {
        CurrentHealth -= damage;

        healthbar.SetHealth(CurrentHealth);
    }
}

