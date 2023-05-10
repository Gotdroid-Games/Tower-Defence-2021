using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BombTowerMenu : MonoBehaviour
{
    Quaity quaity;
    public GameObject Upgradebutton;
    public GameObject SellButton;
    public GameObject BombTower;
    GameObject bombObjList;
    public int[] BombTowerUpgradeMoneyList;
    public int Count;
    public int CountCheck;
    public Image MaxlevelImage;
    public List<GameObject> BombObjList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        BombObjList[0].SetActive(true);
       quaity = Quaity.FindObjectOfType<Quaity>();
    }
    private void OnMouseDown()
    {
        Upgradebutton.SetActive(true);
        SellButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Count <= 2)
        {
            bombObjList = BombObjList[Count];
        }
        CountCheck = Count;

        if (BombObjList != null)
        {
            if (Count == 0)
            {
                BombObjList[0].SetActive(true);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(false);

            }
            if (Count == 1)
            {
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(true);
                BombObjList[2].SetActive(false);

            }
            if (Count == 2)
            {
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(true);

            }
        }
    }

    public void UpgradeBomb()
    {
        Debug.Log(gameObject.name);
        BombTower = gameObject;

        if (quaity._coinText >= 120)
        {
            Count++;

            if (CountCheck ==0)
            {
                quaity.BombTowerUpgradeMoney(120);
                Debug.Log("BombCountcheck = 0");
            }

            if (CountCheck == 1)
            {
                Upgradebutton.gameObject.SetActive(false);
                MaxlevelImage.gameObject.SetActive(true);
                quaity.BombTowerUpgradeMoney(150);
                Debug.Log("BombCountcheck = 1");
            }

            if (CountCheck == 2)
            {
                
                quaity.BombTowerUpgradeMoney(0);
                Debug.Log("BombCountcheck = 2");
            }
        }
    }
}
