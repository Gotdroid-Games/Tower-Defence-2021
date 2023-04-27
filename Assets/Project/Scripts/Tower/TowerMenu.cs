using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    TowerRangeController TowerRangeController;
    RangeUpgrade RangeUpgrade;
    TowerTarget TowerTarget;
    Quaity Quaity;
    
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;
    int countcheck;
    
    private void Start()
    {
        TowerTarget = FindObjectOfType<TowerTarget>();
        TowerRangeController = FindObjectOfType<TowerRangeController>();
        Quaity = FindObjectOfType<Quaity>();
        RangeUpgrade = FindObjectOfType<RangeUpgrade>();
    }
    private void Update()
    {
        if (TowerRangeController.counts >= 2)
        {
            TowerRangeController.counts = 2;
        }

        countcheck = TowerRangeController.counts;
    }

    private void OnMouseDown()
    {
        var up = transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.green);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {
            if (hit.collider != null)
            {
                UpgradeButton1.SetActive(true);
                SellButton.SetActive(true);

                for (int i = 0; i <  TowerRangeController.UIController.Count; i++ )
                {
                    TowerRangeController.UIController[i].SetActive(true);
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    public void Upgrade()
    {
        Debug.Log(gameObject.name);
        Tower = gameObject;

        if (Quaity._coinText >= 120)
        {
            gameObject.GetComponent<TowerRangeController>().counts++;

            if(countcheck<2)
            {
                RangeUpgrade.Attribute();
                Quaity.TowerUpgradeMoney(120);
            }
        }

        for (int i = 0; i < TowerRangeController.UIController.Count; i++)
        {
            TowerRangeController.UIController[i].SetActive(false);
        }

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void Sell()
    {
        Quaity.SellTower(70);
        Destroy(gameObject);
    }
}
