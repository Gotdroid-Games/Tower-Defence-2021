using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    Quaity quaity;
    BuildManager buildManager;
    GameManager GameManager;
    Shop shop;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        shop = GetComponent<Shop>();
        startColor = rend.material.color;
        quaity = FindObjectOfType<Quaity>();
        buildManager = FindObjectOfType<BuildManager>();
        shop = FindObjectOfType<Shop>();
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        
        if(turret != null)
        {
            return;
        }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (quaity._coinText >= GameManager._sniperTowerBuyMoney && shop.bombSelected == false)
        {  
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            quaity.PaidTower(GameManager._sniperTowerBuyMoney);
        }
        //Build a turret (Tarret in�a et)

        if (quaity._coinText >= GameManager._bombTowerBuyMoney && shop.bombSelected == true)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            quaity.PaidBombTower(GameManager._bombTowerBuyMoney);
        }
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
