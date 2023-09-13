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
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Kule zaten var.");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        int towerIndex = -1; // Hangi kuleyi seçildiğini saklamak için bir indeks değişkeni kullanalım.

        if (GameUI._coinText >= GameManager.TowerVaribles[0].TowerMoneyBuy)
        {
            towerIndex = 0; // İlk kule seçildi.
        }
        else if (GameUI._coinText >= GameManager.TowerVaribles[1].TowerMoneyBuy)
        {
            towerIndex = 1; // İkinci kule seçildi.
        }

        if (towerIndex != -1)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[towerIndex].TowerMoneyBuy);

            // Hangi kuleyi seçildiyse ona göre ses efekti çal.
            if (towerIndex == 0 || towerIndex == 1)
            {
                AudioManager.PlaySFX("HackerTowerBuildSFX");
            }
        }
    }
}
