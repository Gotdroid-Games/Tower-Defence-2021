using UnityEngine;
using System.Collections.Generic;
public class TowerMenu : MonoBehaviour
{
    TowerRangeController TowerRangeController;
    RangeUpgrade RangeUpgrade;
    TowerTarget TowerTarget;
    Quaity Quaity;
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
    int countcheck;
    
    private void Start()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        Quaity = FindObjectOfType<Quaity>();
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
    }
    private void Update()
    {
        TowerRangeController = FindObjectOfType<TowerRangeController>();
        countcheck = TowerRangeController.counts;
        if (TowerRangeController.counts >= 2)
        {
            TowerRangeController.counts = 2;
        }

       
    }

    private void OnMouseDown()
    {
        var up = transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.green);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {
            if (hit.collider != null)
            {   
                UpgradeButton1.SetActive(true);
                SellButton.SetActive(true);

                for (int i = 0; i < TowerRangeController.UIController.Count; i++ )
                {
                   TowerRangeController.UIController[i].SetActive(true);
                }
                
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    public void Upgrade()
    {
        Debug.Log(gameObject.name);
        Tower = gameObject;

        if (Quaity._coinText >= 120)
        {
            GetComponent<TowerRangeController>().counts++;

            if(countcheck<2)
            {
                //RangeUpgrade.Attribute();
                Quaity.TowerUpgradeMoney(120);
            }
        }

        for (int i = 0; i <TowerRangeController.UIController.Count; i++)
        {
           TowerRangeController.UIController[i].SetActive(false);
        }

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void Sell()
    {
        Destroy(gameObject);

        if (countcheck == 0)
        {
            Quaity.SellTower(70);
        }

        if (countcheck == 1)
        {
            Quaity.SellTower(100);
        }

        if (countcheck == 2)
        {
            Quaity.SellTower(120);
        }
    }
}
