using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    Quaity quaity;
    BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        quaity = FindObjectOfType<Quaity>();
        buildManager = FindObjectOfType<BuildManager>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        
        if(turret != null)
        {
            return;
        }
        if (quaity._coinText >= 70)
        {
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            quaity.PaidTower(70);
        }
      //Build a turret (Tarret inþa et)

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
