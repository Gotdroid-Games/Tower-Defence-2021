using System.Collections.Generic;
using UnityEngine;

public class TowerRangeController : MonoBehaviour
{
   
    public List<GameObject> UIController = new List<GameObject>();
    public List<GameObject> TouchObjList = new List<GameObject>();
    public GameObject touchGameObj;
    public int counts;
    public int countcheck;

    TowerMenu TowerMenu;


    private void Start()
    {
        TouchObjList[0].SetActive(true);
        TowerMenu = FindObjectOfType<TowerMenu>();
        
    }
    private void Update()
    {
        countcheck = counts;
        if (counts <= 2)
        {
            touchGameObj = TouchObjList[counts];
        }

        if (counts >= 2)
        {
            counts = 2;
        }

        if (countcheck >= 2)
        {
            countcheck = 2;
        }

        if (touchGameObj != null)
        {
            if (counts == 0)
            {
                TowerMenu.Tower=TouchObjList[0];
                TouchObjList[0].SetActive(true);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 1)
            {
                TowerMenu.Tower = TouchObjList[1];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(true);
                TouchObjList[2].SetActive(false);
            }

            if (counts == 2)
            {
                TowerMenu.Tower = TouchObjList[2];
                TouchObjList[0].SetActive(false);
                TouchObjList[1].SetActive(false);
                TouchObjList[2].SetActive(true);
            }
        }
    }
}
