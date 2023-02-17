using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //private void Start()
    //{
    //    //_healthSlider = GetComponent<Slider>();
    //}

    public void SetSlider(Slider healthSlider)
    {
        slider = healthSlider;
    } 
    //public void SetMaxHealth(int maxHealth)
    //{
    //    _healthSlider.maxValue = maxHealth;
    //    _healthSlider.value = maxHealth;
    //}   
    //public void SetHealth(float health)
    //{
    //    _healthSlider.value = health;
    //}
}
