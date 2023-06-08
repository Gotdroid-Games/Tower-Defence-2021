using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClickDetector : MonoBehaviour
{
    TowerMenu TowerMenu;
    private void Start()
    {
        TowerMenu = FindObjectOfType<TowerMenu>();

    }
    private void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {
            bool isClickedOnGameObject = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == TowerMenu.UpgradeButton1 || hit.collider.gameObject == TowerMenu.SellButton)
                {
                    Debug.Log("objeye tıklandı");

                    if (TowerMenu.sniperTowerCount != 2)
                    {
                        TowerMenu.UpgradeButton1.SetActive(true);

                    }
                    TowerMenu.SellButton.SetActive(true);
                   // bombmenu.towerUI.SetActive(true);
                    isClickedOnGameObject = true;

                }
            }

            if (!isClickedOnGameObject)
            {
                Debug.Log("Başka bir yere tıklandı");
                TowerMenu.UpgradeButton1.SetActive(false);
                TowerMenu.SellButton.SetActive(false);
            }
        }
    }
}
