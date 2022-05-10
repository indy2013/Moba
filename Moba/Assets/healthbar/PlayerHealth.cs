using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider playerSlider3D;
    Slider playerSlider2D;

    

    stats statsScript;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("player").GetComponent<stats>();

       playerSlider2D = GetComponent<Slider>();

        playerSlider3D.maxValue = statsScript.maxHealth;
        playerSlider2D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;
    }

    void Update()
    {
        playerSlider2D.value = statsScript.health;
        playerSlider3D.value = playerSlider2D.value;  
    }
}

