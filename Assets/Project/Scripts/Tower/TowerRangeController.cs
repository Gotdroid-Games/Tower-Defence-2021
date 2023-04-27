using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TowerRangeController : MonoBehaviour
{
    
    [SerializeField] public static TowerRangeController instance;
    public List<GameObject> UIController = new List<GameObject>();
    public List<GameObject> TouchObjList = new List<GameObject>();
    public GameObject touchGameObj;
    public int counts;
    public int countcheck;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        TouchObjList[0].SetActive(true);
    }
    private void Update()
    {
        countcheck = counts;
        if (counts <= 2)
        {
            touchGameObj = TouchObjList[counts];
        }

        if(counts>=2)
        {
            counts = 2;
        }

        if(countcheck>=2)
        {
            countcheck = 2;
        }

        if (touchGameObj != null)
        {
            if (counts == 0)
            {
                TowerMenu.instance.Tower=TouchObjList[0];
                TouchObjList[0].SetActive(true);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 1)
            {
                TowerMenu.instance.Tower = TouchObjList[1];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(true);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 2)
            {
                TowerMenu.instance.Tower = TouchObjList[2];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(true);
            }
        }
    }
}
