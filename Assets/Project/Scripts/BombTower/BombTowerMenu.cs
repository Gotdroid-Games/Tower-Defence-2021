using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTowerMenu : MonoBehaviour
{
    Quaity quaity;
    public GameObject Upgradebutton;
    public GameObject SellButton;
    public GameObject BombTower;
    public int[] BombTowerUpgradeMoneyList;
    public List<GameObject> BombObjList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Quaity.FindObjectOfType<Quaity>();
    }
    private void OnMouseDown()
    {
        Upgradebutton.SetActive(true);
        SellButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeBomb()
    {
        Debug.Log(gameObject.name);
        BombTower = gameObject;
    }
}
