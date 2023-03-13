using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public static TowerMenu instance;
    TowerTarget TowerTarget;
    



    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
        
    int TowerCount;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        
        TowerTarget = TowerTarget.instance;
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

                for (int i = 0; i < TowerRangeController.instance.UIController.Count; i++)
                {
                    TowerRangeController.instance.UIController[i].SetActive(true);
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    private void Update()
    {
        
    }

    public void Upgrade()
    {
        Debug.Log(gameObject.name);
        Tower = gameObject;
        gameObject.GetComponent<TowerRangeController>().counts++;

        if (Quaity.Instance._coinText >= 120)
        {
            Quaity.Instance.PaidTower(120);
        }

        for (int i = 0; i < TowerRangeController.instance.UIController.Count; i++)
        {
            TowerRangeController.instance.UIController[i].SetActive(false);
        }

        RangeUpgrade.instance.Attribute();
        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void Sell()
    {
        Quaity.Instance.SellTower(70);
        Destroy(gameObject);
    }
}
