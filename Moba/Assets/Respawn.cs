using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    stats statsScript;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("player").GetComponent<stats>();
    }
   

    void Update()
    {
        if(statsScript.health <= 5)
        {
            transform.player.position = spawnPoint.position;
        }
    }
}
