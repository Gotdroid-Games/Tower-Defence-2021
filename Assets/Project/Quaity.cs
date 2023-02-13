using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Quaity : MonoBehaviour
{
    
    public static Quaity Instance;
    public TextMeshProUGUI heartText;
    public int _heartText = 1;
    public Rigidbody rb;

    private void Start()
    {
        _heartText = 1;
        
    }
    private void Update()
    {
        DefeatMenu();
    }

    void Damage(int damage)
    {
        _heartText -= damage;
        heartText.text = _heartText.ToString();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Damage(1);
        }   
    }

    void DefeatMenu()
    {
        if(_heartText<=0)
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
}
