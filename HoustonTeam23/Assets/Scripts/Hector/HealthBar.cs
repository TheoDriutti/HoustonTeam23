using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public List<GameObject> fill;
    public int index = 0;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;


    }

    public void SetHealth(int health)
    {
        slider.value = health;

        GameObject vies = fill[index];
        vies.SetActive(false);
        index++;
    }


}
