using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float attackDmg;
    public float attackSpeed;
    public float attackTime;
    public float moveSpeed;
    HeroCombat heroCombatScript;
   
    

    void Start()
    {
        heroCombatScript = GameObject.FindGameObjectWithTag("player").GetComponent<HeroCombat>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
            heroCombatScript.targetedEnemy = null;
            heroCombatScript.performMeleeAttack = false;
        }
    }
}
