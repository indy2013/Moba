using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manabar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(int mana)
    {

        slider.maxValue = mana;
        slider.value = mana;
    }

    public void SetHealth(int mana)
    {

        slider.value = mana;
    }
}
