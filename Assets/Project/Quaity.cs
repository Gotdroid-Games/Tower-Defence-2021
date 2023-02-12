using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaity : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject==CompareTag("Enemy"))
        {
            //GameUI.Instance.Healt(20);
        }
    }
}
