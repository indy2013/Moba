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


    void Update()
    {
        if (health <= 0) {
            //Destroy(gameObject);    Dit destroyed ook player dus deze moet aan gepast worden dat dit alleen de minion destroyed
            heroCombatScript.targetedEnemy = null;
            heroCombatScript.performMeleeAttack = false;
        }
    }
}
