using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    TowerTarget TowerTarget;
    public static TowerMenu instance;
    public GameObject UpgradeButton1;
    public GameObject Tower;
    public GameObject SellButton;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        
        TowerTarget = TowerTarget.instance;
    }
    private void Update()
    {
        if (TowerRangeController.instance.counts >= 2)
        {
            TowerRangeController.instance.counts = 2;
        }
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

                for (int i = 0; i < TowerRangeController.instance.UIController.Count; i++)
                {
                    TowerRangeController.instance.UIController[i].SetActive(true);
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    public void Upgrade()
    {
        Debug.Log(gameObject.name);
        Tower = gameObject;

        if (Quaity.Instance._coinText >= 120)
        {
            Quaity.Instance.TowerUpgradeMoney(120);
            gameObject.GetComponent<TowerRangeController>().counts++;

            if (TowerRangeController.instance.counts <= 2)
            {
                RangeUpgrade.instance.Attribute();
            }
        }

        for (int i = 0; i < TowerRangeController.instance.UIController.Count; i++)
        {
            TowerRangeController.instance.UIController[i].SetActive(false);
        }

        UpgradeButton1.SetActive(false);
        SellButton.SetActive(false);
    }

    public void Sell()
    {
        Quaity.Instance.SellTower(70);
        Destroy(gameObject);
    }
}
