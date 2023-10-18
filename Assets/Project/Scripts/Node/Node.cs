using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Node : MonoBehaviour
{
    public AudioManager AudioManager;
    public Vector3 positionOffset;
    public Canvas TowerselectionImage;
    private GameObject turret;

    private Renderer rend;

    public BuildManager buildManager;
    GameManager GameManager;
    GameUI GameUI;
    public Shop shop;
    public int[] towerBuildCount;

    public bool towerBuildControl = false;
    public GameObject[] towerPrefabs;
    public GameObject[] TowerBuildUI;
    bool hasTurret = false;
    private void Start()
    {
        Debug.Log("Node Start method called.");
        rend = GetComponent<Renderer>();
        shop = GetComponent<Shop>();
        GameManager = FindObjectOfType<GameManager>();
        GameUI = FindObjectOfType<GameUI>();
    }

    private void Update()
    {
        NodeClick();
        Debug.Log(towerBuildControl);
    }
    public void PurchaseLaserTurret()
    {
        towerBuildCount[1] = 0;
        towerBuildCount[2] = 0;
        towerBuildCount[3] = 0;
        towerBuildCount[0]++;

        if (towerBuildCount[0] == 2)
        {
            turret = (GameObject)Instantiate(towerPrefabs[0], transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[0].TowerMoneyBuy);
            TowerselectionImage.gameObject.SetActive(false);
            //AudioManager.PlaySFX("");
            towerBuildCount[0] = 0;
            towerBuildControl = true;
        }

    }

    public void PurchaseBombTurret()
    {
        towerBuildCount[0] = 0;
        towerBuildCount[2] = 0;
        towerBuildCount[3] = 0;

        towerBuildCount[1]++;
        if (towerBuildCount[1] == 2)
        {
            turret = (GameObject)Instantiate(towerPrefabs[1], transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[1].TowerMoneyBuy);
            TowerselectionImage.gameObject.SetActive(false);
            //AudioManager.PlaySFX("");
            towerBuildCount[1] = 0;
            towerBuildControl = true;

        }

    }
    public void PurchaseHackerTower()
    {
        towerBuildCount[0] = 0;
        towerBuildCount[1] = 0;
        towerBuildCount[3] = 0;

        towerBuildCount[2]++;
        if (towerBuildCount[2] == 2)
        {
            turret = (GameObject)Instantiate(towerPrefabs[2], transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[2].TowerMoneyBuy);
            TowerselectionImage.gameObject.SetActive(false);
            AudioManager.PlaySFX("HackerTowerBuildSFX");
            towerBuildCount[2] = 0;
            towerBuildControl = true;
        }

    }

    public void PurchaseSoldierTower()
    {
        towerBuildCount[0] = 0;
        towerBuildCount[1] = 0;
        towerBuildCount[2] = 0;

        towerBuildCount[3]++;
        if (towerBuildCount[3] == 2)
        {
            turret = (GameObject)Instantiate(towerPrefabs[3], transform.position + positionOffset, transform.rotation);
            GameUI.DecreaseCoinValue(GameManager.TowerVaribles[3].TowerMoneyBuy);
            TowerselectionImage.gameObject.SetActive(false);
            //AudioManager.PlaySFX("");
            towerBuildCount[3] = 0;
            towerBuildControl = true;
        }

    }

    public void NodeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject || hit.collider.gameObject == TowerBuildUI[0] || hit.collider.gameObject == TowerBuildUI[1] ||
                    hit.collider.gameObject == TowerBuildUI[2] || hit.collider.gameObject == TowerBuildUI[3])
                {
                    if (towerBuildControl == false)
                    {
                        TowerselectionImage.gameObject.SetActive(true);
                    }
                }
                else
                {
                    TowerselectionImage.gameObject.SetActive(false);
                    towerBuildCount[0] = 0;
                    towerBuildCount[1] = 0;
                    towerBuildCount[2] = 0;
                    towerBuildCount[3] = 0;
                }
            }
        }

    }
}
