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
                if (hit.collider.gameObject == gameObject)
                {
                    isClickedOnGameObject = true;
                }
            }

            if (!isClickedOnGameObject)
            {
                Debug.Log("Başka bir yere tıklandı");
                bombmenu.towerUI.SetActive(false);
            }
        }
    }
}

