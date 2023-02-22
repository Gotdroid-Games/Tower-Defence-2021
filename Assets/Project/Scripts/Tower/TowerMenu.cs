using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public GameObject UpgradeButton;

    private void OnMouseDown()
    {
        if(!UpgradeButton.activeSelf)
        {
            UpgradeButton.SetActive(true);
        }

        else if (UpgradeButton.activeSelf)
        {
            UpgradeButton.SetActive(false);
        }
    }

    
}
