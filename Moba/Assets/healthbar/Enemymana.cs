using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymana : MonoBehaviour
{
    public int MaxMana = 100;
    public int CurrentMana;


    public manabar manabar;


    void Start()
    {
        CurrentMana = MaxMana;
        manabar.SetMaxMana(MaxMana);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        CurrentMana -= damage;

        manabar.SetHealth(CurrentMana);
    }
}
