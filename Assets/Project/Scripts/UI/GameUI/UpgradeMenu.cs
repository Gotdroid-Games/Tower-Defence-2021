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
    
   public static float newfirecontdown;
    private void Start()
    {
        newfirecontdown = 1f;
    }
    
     public GameObject GameObject;
     public GameObject UpgradeMenuPrefab;
     public void deneme()
     {
        newfirecontdown = 0.2f;
        //GameValue.instance.NewFireCountDown = 0.2f;
        Debug.Log(TowerTarget.instance.fireCountdown);
        UpgradeMenuPrefab.SetActive(false);
     }  
   
}
