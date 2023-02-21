using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Quaity : MonoBehaviour
{
    public static Quaity Instance;
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI CoinText;
    public int _coinText = 0;
    public int _heartText = 20;
    public int _waveText = 0;
    //public bool CoinControl;


    private void Start()
    {
        Instance = this;
        _heartText = 20;
        _waveText = 0;
        _coinText = 0;
    }

    private void Update()
    {
        if (_heartText <= 0)
        {
            gameObject.SetActive(false);
        }

        WaveCounter();
    }

    private void OnDisable()
    {
        DefeatMenu();
    }

    void Damage(int damage)
    {
        _heartText -= damage;
        heartText.text = _heartText.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(1);
            Destroy(other.gameObject);
        }
    }

    public void DefeatMenu()
    {
        if (_heartText <= 0)
        {
            GameUI.Instance.DefeatMenu();
        }
    }
    public void PauseOrResume()
    {
        if (GameUI.Instance._Button.GameUIButtons[2].activeSelf && GameUI.Instance._Button.GameUIButtons[3].activeSelf)
        {
            Time.timeScale = 1;
        }
    }

    void WaveValue(int wave)
    {
        _waveText += wave;
        WaveText.text = _waveText.ToString();
    }

    void WaveCounter()
    {
        if (WaveSpawner.Instance.countdown <= 0)
        {
            WaveValue(1);
        }
    }

    public void CoinValue(int coin)
    {
        _coinText += coin;
        CoinText.text = _coinText.ToString();
    }

    
}
