using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;      // Ok prefab�
    public Transform startPoint;        // Ba�lang�� noktas�
    public Transform endPoint;          // Biti� noktas�
    public int numArrows = 10;          // Olu�turulacak ok say�s�
    public float arrowSpeed = 10f;      // Ok h�z�

    private bool isSpawning = false;    // Ok spawn i�leminin devam edip etmedi�ini kontrol etmek i�in kullan�l�r

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) // Fare pozisyonu buton �zerindeyken
        {
            if (Input.GetMouseButtonDown(0)) // Fare t�klamas� alg�land���nda
            {
                StartSpawning();
            }
        }
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;

            for (int i = 0; i < numArrows; i++)
            {
                GameObject arrow = Instantiate(arrowPrefab, startPoint.position, Quaternion.identity); // Ok objesini olu�turur
                arrow.GetComponent<Rigidbody>().velocity = (endPoint.position - startPoint.position).normalized * arrowSpeed; // Oku hedefe do�ru hareket ettirir
            }
        }
    }
}