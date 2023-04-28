using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    Quaity Quaity;
    BuildManager BuildManager;
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        Quaity=FindObjectOfType<Quaity>();
        BuildManager = FindObjectOfType<BuildManager>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.GetTurretToBuild() == null)
            return;

        
        if(turret != null)
        {
            return;
        }
        if (Quaity._coinText >= 70)
        {
            GameObject turretToBuild = BuildManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            Quaity.PaidTower(70);
        }

        //Build a turret (Tarret inþa et)

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (BuildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
