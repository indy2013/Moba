using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_movement : MonoBehaviour
{
   public  NavMeshAgent agent;
   public float rotateSpeedMovement = 0.1f;
   public float rotateVelocity;

    private HeroCombat herocombatScript;
    private stats movespeed;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        herocombatScript = GetComponent<HeroCombat>();
        movespeed = GetComponent<stats>();

    }


    void Update()
    {

        if (herocombatScript.targetedEnemy != null) {
            if (herocombatScript.targetedEnemy.GetComponent<HeroCombat>() != null)
            {
                if (herocombatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    herocombatScript.targetedEnemy = null;
                }
            }
        }




        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "floor") {
                    //movement
                    agent.SetDestination(hit.point);
                    herocombatScript.targetedEnemy = null;
                    agent.stoppingDistance = 0;

                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }
               
            }
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                agent.speed += 1;

                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }

        }
        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                agent.speed -= 1;

                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }*/


    }
}