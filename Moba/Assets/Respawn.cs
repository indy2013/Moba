using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform spawnPoint;
    stats statsScript;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("player").GetComponent<stats>();
    }
   

    void Update()
    {
        if(statsScript.health <= 0)
        {
            player.transform.position = spawnPoint.transform.position;
            statsScript.health = statsScript.maxHealth;
        }
        
    }
}
