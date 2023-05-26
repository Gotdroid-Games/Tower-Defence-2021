using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    BombTowerMenu bombmenu;
    private void Start()
    {
        bombmenu = FindObjectOfType<BombTowerMenu>();
        
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
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == bombmenu._upgradeButton || hit.collider.gameObject == bombmenu.SellButton)
                {
                    Debug.Log("objeye tıklandı");
                    
                   if( bombmenu.bombTowerCountCheck!=2)
                    {
                        bombmenu._upgradeButton.SetActive(true);
                        
                    }
                    bombmenu.SellButton.SetActive(true);
                 //   bombmenu.towerUI.SetActive(true);
                    isClickedOnGameObject = true;
                    
                }
            }

            if (!isClickedOnGameObject)
            {
                Debug.Log("Başka bir yere tıklandı");
                bombmenu._upgradeButton.SetActive(false);
                bombmenu.SellButton.SetActive(false);
                // bombmenu.towerUI.SetActive(false);
            }
        }
    }
}

