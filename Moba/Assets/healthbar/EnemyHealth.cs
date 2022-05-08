using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            TakeDamage(10);
        }
        if (CurrentHealth < 0 || CurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthbar.SetHealth(CurrentHealth);
    }
}
