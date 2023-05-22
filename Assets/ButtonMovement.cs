using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public GameObject objectPrefab; // Instantiate edilecek obje prefab�
    public Transform[] waypoints; // Hedef noktalar�n listesi
    public float interval = 1f; // Instantiate aral���
    public float speed = 100f; // Hareket h�z�

    private int objectsSpawned = 0; // Instantiate edilen obje say�s�
    private int currentWaypointIndex = 0; // Mevcut hedef nokta dizinini takip etmek i�in kullan�l�r
    private float timer = 0f; // Instantiate aral���n� takip etmek i�in kullan�l�r

    private bool isMoving = false; // Objenin hareket edip etmedi�ini kontrol etmek i�in kullan�l�r

    
    GameUI GameUI;
    private void Start()
    {
        GameUI = FindObjectOfType<GameUI>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval && objectsSpawned < 1)
        {
            if (GameUI._Button.GameUIButtons[14].activeSelf)
            {
                SpawnObject();
            }
            timer = 0f;
        }

        if (isMoving)
        {
            MoveToWaypoint();
        }

        if (isMoving==false)
        {
            if (GameUI._Button.GameUIButtons[14].activeSelf==false)
            {
                Debug.Log("girdi");
                transform.position = waypoints[0].position;
                currentWaypointIndex = 0;
                objectPrefab.SetActive(false);
                StopMoving();
            }
        }
    }

    private void SpawnObject()
    {
        GameObject obj = Instantiate(objectPrefab, waypoints[0].position, Quaternion.identity);
        ButtonMovement buttonMovement = obj.GetComponent<ButtonMovement>();

        buttonMovement.waypoints = waypoints;
        buttonMovement.speed = speed;

        buttonMovement.StartMoving();

        objectsSpawned++;
        
    }

    public void StopMoving()
    {
            isMoving = false;
       
    }

    public void StartMoving()
    {
        
            if (!isMoving)
            {
                isMoving = true;
            }
        
    }

    private void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                isMoving = false;
                currentWaypointIndex = 0;
                Destroy(gameObject);
            }
        }
    }
}
