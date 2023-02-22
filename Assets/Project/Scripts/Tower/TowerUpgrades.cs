using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    public int damage = 15;
    public static TowerUpgrades Instance;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        damage = 15;
    }

    private void Update()
    {
        Debug.Log(damage);
        UpgradeButton();
    }
    private void OnMouseDown()
    {
        
    }
    
    public void UpgradeButton()
    {
        if(Quaity.Instance._coinText >= 100)
        {
            Quaity.Instance.TowerUpgradeMoney(120);
            damage = 75;
            Debug.Log("sa");
        }
        //3 farkl� buton olu�turup her buton seviyesine g�re bir hasar atamas� yap�lacak e�er ve setactive kullanarak kontrol edilecek ko�ul y�k�laca�� i�in 1 kez artt�racak
    }
}
