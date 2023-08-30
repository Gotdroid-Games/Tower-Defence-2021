using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public AudioManager AudioManager;
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    GameManager GameManager;
    GameUI GameUI;
    Shop shop;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        shop = GetComponent<Shop>();
        startColor = rend.material.color;
        buildManager = FindObjectOfType<BuildManager>();
        shop = FindObjectOfType<Shop>();
        GameManager = FindObjectOfType<GameManager>();
        GameUI = FindObjectOfType<GameUI>();

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;


        if (turret != null)
        {
            return;
        }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (GameUI._coinText >= GameManager.TowerVaribles[0].TowerMoneyBuy && shop.bombSelected == false)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneyBuy);
        }
        //Build a turret (Tarret in�a et)

        if (GameUI._coinText >= GameManager.TowerVaribles[1].TowerMoneyBuy && shop.bombSelected == true)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneyBuy);
        }

        if (buildManager.towerPrefabs[2] == true)
        {
            AudioManager.PlaySFX("HackerTowerBuildSFX");
        }
    }
}
