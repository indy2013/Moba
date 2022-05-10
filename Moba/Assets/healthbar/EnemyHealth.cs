using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider enemySlider3D;
   

    stats statsScript;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<stats>();

        

        enemySlider3D.maxValue = statsScript.maxHealth;
        
        statsScript.health = statsScript.maxHealth;
    }

    void Update()
    {
        enemySlider3D.value = statsScript.health;
   
    }
}
