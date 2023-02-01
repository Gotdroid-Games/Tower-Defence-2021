using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider _healthSlider;

    private void Start()
    {
        //_healthSlider = GetComponent<Slider>();
    }

    public void SetSlider(Slider healthSlider)
    {
        _healthSlider = healthSlider;
    }

    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }   
    public void SetHealth(float health)
    {
        _healthSlider.value = health;
    }    
}
