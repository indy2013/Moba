using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Transform spawnPoint;
    stats statsScriptEnemy;

    void Start()
    {
        statsScriptEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<stats>();
    }
   

    void Update()
    {
        if(statsScriptEnemy.health <= 0)
        {
            enemy.transform.position = spawnPoint.transform.position;
            statsScriptEnemy.health = statsScriptEnemy.maxHealth;
        }
        
    }
}
