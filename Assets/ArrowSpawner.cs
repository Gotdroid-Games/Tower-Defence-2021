using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;      // Ok prefabý
    public Transform startPoint;        // Baþlangýç noktasý
    public Transform endPoint;          // Bitiþ noktasý
    public int numArrows = 10;          // Oluþturulacak ok sayýsý
    public float arrowSpeed = 10f;      // Ok hýzý

    private bool isSpawning = false;    // Ok spawn iþleminin devam edip etmediðini kontrol etmek için kullanýlýr

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) // Fare pozisyonu buton üzerindeyken
        {
            if (Input.GetMouseButtonDown(0)) // Fare týklamasý algýlandýðýnda
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
                GameObject arrow = Instantiate(arrowPrefab, startPoint.position, Quaternion.identity); // Ok objesini oluþturur
                arrow.GetComponent<Rigidbody>().velocity = (endPoint.position - startPoint.position).normalized * arrowSpeed; // Oku hedefe doðru hareket ettirir
            }
        }
    }
}