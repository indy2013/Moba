using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputtargeting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;


    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        //minion Targeting
        if (Input.GetMouseButtonDown(1)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<Targetable>().enemytype == Targetable.Enemytype.minion)
                {
                    selectedHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
                }
            }
            else if (hit.collider.gameObject.GetComponent<Targetable>() == null) {
                selectedHero.GetComponent<HeroCombat>().targetedEnemy = null;
            }
        }
    }
}
