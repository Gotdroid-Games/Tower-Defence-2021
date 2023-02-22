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
        //3 farklý buton oluþturup her buton seviyesine göre bir hasar atamasý yapýlacak eðer ve setactive kullanarak kontrol edilecek koþul yýkýlacaðý için 1 kez arttýracak
    }
}
