using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilities : MonoBehaviour
{
    [Header("Abilty 1")]
    public Image abiltyImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode abilty1;

    [Header("Abilty 2")]
    public Image abiltyImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode abilty2;

    [Header("Abilty 3")]
    public Image abiltyImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode abilty3;

    [Header("Abilty 4")]
    public Image abiltyImage4;
    public float cooldown4 = 5;
    bool isCooldown4 = false;
    public KeyCode abilty4;



    void Start()
    {
        abiltyImage1.fillAmount = 0;
        abiltyImage2.fillAmount = 0;
        abiltyImage3.fillAmount = 0;
        abiltyImage4.fillAmount = 0;
    }

   
    void Update()
    {
        Abilty1();
        Abilty2();
        Abilty3();
        Abilty4();
    }

    void Abilty1()
    {
        if(Input.GetKey(abilty1) && isCooldown == false)
        {
            isCooldown = true;
            abiltyImage1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abiltyImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abiltyImage1.fillAmount <= 0)
            {
                abiltyImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Abilty2()
    {
        if (Input.GetKey(abilty2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abiltyImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abiltyImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abiltyImage2.fillAmount <= 0)
            {
                abiltyImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Abilty3()
    {
        if (Input.GetKey(abilty3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abiltyImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abiltyImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abiltyImage3.fillAmount <= 0)
            {
                abiltyImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Abilty4()
    {
        if (Input.GetKey(abilty4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abiltyImage4.fillAmount = 1;
        }

        if (isCooldown4)
        {
            abiltyImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abiltyImage4.fillAmount <= 0)
            {
                abiltyImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
