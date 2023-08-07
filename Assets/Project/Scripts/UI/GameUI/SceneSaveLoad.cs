using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
public class SceneSaveLoad : MonoBehaviour
{
    private string filepath;
    private int LastUnlockedSceneIndex=2;
    void Start()
    {
        filepath = Application.dataPath + "/sceneIndex.json";
        LoadSceneIndex();
    }
    public void SaveSceneIndex()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex>LastUnlockedSceneIndex)
        {
            LastUnlockedSceneIndex = activeSceneIndex;
        }
        string jsonData = JsonConvert.SerializeObject(activeSceneIndex);
        System.IO.File.WriteAllText(filepath, jsonData);

        Debug.Log("Sahnr indexi kaydedildi");
    }

    public void LoadSceneIndex()
    {
        if (System.IO.File.Exists(filepath))
        {
            string jsonData = System.IO.File.ReadAllText(filepath);
            LastUnlockedSceneIndex = JsonConvert.DeserializeObject<int>(jsonData);
        }
        else
        {
            Debug.Log("Kayıtlı bir sahne indexi yok.");
        }
    }
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex <= LastUnlockedSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("bu sahneyi oynayamazsınız");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveSceneIndex();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSceneIndex();
        }
    }
}
