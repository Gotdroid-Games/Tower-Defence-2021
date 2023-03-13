using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu instance;
    public static float newfirecontdown;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        newfirecontdown = 1f;
    }
    
     //public GameObject GameObject;
     //public GameObject UpgradeMenuPrefab;
     public void Deneme()
     {
        newfirecontdown = 0.2f;
        GameValue.instance.NewFireCountDown = 0.2f;
        //Debug.Log(TowerTarget.instance.fireCountdown);
        //UpgradeMenuPrefab.SetActive(false);
     }  
   
}
