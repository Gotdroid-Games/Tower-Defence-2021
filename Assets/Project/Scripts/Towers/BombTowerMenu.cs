using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombTowerMenu : MonoBehaviour
{
    Quaity Quaity;
    GameManager GameManager;
    public GameObject _upgradeButton;
    public GameObject SellButton;
    public GameObject BombTower;
    GameObject bombObjList;
    public int[] BombTowerUpgradeMoneyList;
    public int Count;
    public int CountCheck;
    public Image MaxlevelImage;
    public Button BombTowerUpgradeButton;
    public List<GameObject> BombObjList = new List<GameObject>();

    public TextMeshProUGUI BombTowerUpgradeMoneyText;

    void Start()
    {
        Count = 0;
        BombObjList[0].SetActive(true);
        Quaity = FindObjectOfType<Quaity>();
        GameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        _upgradeButton.SetActive(true);
        SellButton.SetActive(true);
    }

    void Update()
    {

        if (Count <= 2)
        {
            bombObjList = BombObjList[Count];
        }

        CountCheck = Count;

        if (BombObjList != null)
        {
            if (Count == 0)
            {
                BombObjList[0].SetActive(true);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(false);

            }
            if (Count == 1)
            {
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(true);
                BombObjList[2].SetActive(false);

            }
            if (Count == 2)
            {
                BombObjList[0].SetActive(false);
                BombObjList[1].SetActive(false);
                BombObjList[2].SetActive(true);

            }
        }

        if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[0] && CountCheck == 0)
        {
            BombTowerUpgradeButton.interactable = true;
            MaxlevelImage.gameObject.SetActive(false);
            BombTowerUpgradeMoneyText.text = GameManager._bombTowerUpgradeMoney[0].ToString();
            Debug.Log("dosfghdfsgdfs");
        }
        else if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[1] && CountCheck == 1)
        {
            BombTowerUpgradeButton.interactable = true;
            MaxlevelImage.gameObject.SetActive(false);
            BombTowerUpgradeMoneyText.text = GameManager._bombTowerUpgradeMoney[1].ToString();
        }
        else
        {
            BombTowerUpgradeButton.interactable = false;
        }
    }

    public void UpgradeBomb()
    {
        Count++;
        Debug.Log(gameObject.name);
        BombTower = gameObject;

        if (Quaity._coinText >= GameManager._bombTowerUpgradeMoney[0])
        {


            if (CountCheck == 0)
            {
                Quaity.BombTowerUpgradeMoney(GameManager._bombTowerUpgradeMoney[0]);
                Debug.Log("BombCountcheck = " + CountCheck);
            }

            if (CountCheck == 1)
            {
                _upgradeButton.gameObject.SetActive(false);
                MaxlevelImage.gameObject.SetActive(true);
                Quaity.BombTowerUpgradeMoney(GameManager._bombTowerUpgradeMoney[1]);
                Debug.Log("BombCountcheck = " + CountCheck);
            }
        }
    }
}
