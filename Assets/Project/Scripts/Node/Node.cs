using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Node : MonoBehaviour
{
    public AudioManager AudioManager;
    public Color hoverColor;
    public Vector3 positionOffset;
    public Canvas TowerselectionImage;
    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    public BuildManager buildManager;
    GameManager GameManager;
    GameUI GameUI;
    public Shop shop;

    public GameObject[] towerPrefabs;
    bool hasTurret = false;
    private void Start()
    {
        Debug.Log("Node Start method called.");
        rend = GetComponent<Renderer>();
        shop = GetComponent<Shop>();
        startColor = rend.material.color;
        
        //buildManager = FindObjectOfType<BuildManager>();
        //shop = FindObjectOfType<Shop>();
        GameManager = FindObjectOfType<GameManager>();
        GameUI = FindObjectOfType<GameUI>();
    }

    private void OnMouseDown()
    {
        
        TowerselectionImage.gameObject.SetActive(true);
        
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
        buildManager.turretToBuild = null;
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
            
             
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[towerIndex].TowerMoneyBuy);
            TowerselectionImage.gameObject.SetActive(false);

            if (towerIndex == 0)
            {
                PurchaseStandTurret();
                hasTurret = true; // Kule inşa edildiği zaman kontrol değişkenini true yap
            }
            else if (towerIndex == 1)
            {
                PurchaseAnotherTurret();
                hasTurret = true; // Kule inşa edildiği zaman kontrol değişkenini true yap
            }

            // Hangi kuleyi seçildiyse ona göre ses efekti çal.
            if (towerIndex == 0 || towerIndex == 1)
            {
                AudioManager.PlaySFX("HackerTowerBuildSFX");
            }
            
        }
        
    }
    public void PurchaseStandTurret()
    {
        
        turret = (GameObject)Instantiate(towerPrefabs[0], transform.position + positionOffset, transform.rotation);
    }

    public void PurchaseAnotherTurret()
    {
        turret = (GameObject)Instantiate(towerPrefabs[1], transform.position + positionOffset, transform.rotation);
    }
    public void PurchaseHackerTower()
    {
        turret = (GameObject)Instantiate(towerPrefabs[2], transform.position + positionOffset, transform.rotation);
    }

    public void PurchaseSoldierTower()
    {
        turret = (GameObject)Instantiate(towerPrefabs[3], transform.position + positionOffset, transform.rotation);
    }




}
