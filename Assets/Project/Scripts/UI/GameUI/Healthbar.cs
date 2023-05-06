using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    public void SetSlider(Slider healthSlider)
    {
        slider = healthSlider;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }


}
