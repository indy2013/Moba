using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged };
    public enum HeroAttackDmg { AD, AP };
    public HeroAttackType heroattacktype;
    public HeroAttackDmg heroattackdmg;

    public GameObject targetedEnemy;
    public float attackrange;
    public float RotateSpeedForAttack;

    private player_movement movescript;
    private stats statsScript;
    private Animator anim;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;

    void Start()
    {
        movescript = GetComponent<player_movement>();
        statsScript = GetComponent<stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null) {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackrange)
            {
                movescript.agent.SetDestination(targetedEnemy.transform.position);
                movescript.agent.stoppingDistance = attackrange;

                //rotation
                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref movescript.rotateVelocity,
                    RotateSpeedForAttack * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
            else {
                if (heroattacktype == HeroAttackType.Melee) {
                    if (performMeleeAttack) {
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }
    IEnumerator MeleeAttackInterval() {
        performMeleeAttack = false;
        // anim.SetBool("Basic attack", true);
        yield return new WaitForSeconds(statsScript.attackTime/ statsScript.attackSpeed);  //statsScript.attackTime / ((100 + statsScript.attackSpeed) * 0.01f
        if (targetedEnemy == null) {
            // anim.SetBool("Basic attack", true);
            performMeleeAttack = true;
        }
        Meleeattack();
    }

    public void Meleeattack()
    {
        if(targetedEnemy != null)
        {

            if (targetedEnemy.GetComponent<Targetable>().enemytype == Targetable.Enemytype.minion)
            {
                if(heroattackdmg == HeroAttackDmg.AD)
                {
                    targetedEnemy.GetComponent<stats>().health -= statsScript.attackDmg / (1 + (100 / targetedEnemy.GetComponent<stats>().armor));
                }
                if(heroattackdmg == HeroAttackDmg.AP)
                {
                    targetedEnemy.GetComponent<stats>().health -= statsScript.attackDmg / (1 + (100 / targetedEnemy.GetComponent<stats>().magicRes));
                }

            }
        }

        performMeleeAttack = true;
    }
}
