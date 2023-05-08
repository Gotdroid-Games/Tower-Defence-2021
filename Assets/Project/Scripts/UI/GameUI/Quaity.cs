using System.Collections;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Quaity : MonoBehaviour
{


    GameUI GameUI;
    WaveSpawner WaveSpawner;
    GameManager GameManager;
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI CoinText;

    public int _coinText;
    public int _heartText;
    public int _waveText;
    public float Product;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
        GameUI = FindObjectOfType<GameUI>();
        WaveSpawner = FindObjectOfType<WaveSpawner>();
        GameManager = FindObjectOfType<GameManager>();

        

    }

    private void Update()
    {
        WaveText.text = _waveText.ToString();
        CoinText.text = _coinText.ToString();
        heartText.text = _heartText.ToString();

        if (_heartText <= 0 || _waveText >= 12)
        {
            gameObject.SetActive(false);
        }

        if (_coinText <= 0)
        {
            _coinText = 0;
        }

        WaveCounter();
    }

    private void OnDisable()
    {
        DefeatMenu();
        Winning();
    }

    void Damage(int damage)
    {
        _heartText -= damage;
        heartText.text = _heartText.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("GorillaRobot") || other.gameObject.CompareTag("SupurgeRobot"))
        {
            Damage(1);
            Destroy(other.gameObject);
        }
    }

    public void DefeatMenu()
    {
        if (_heartText <= 0)
        {
            GameUI.DefeatMenu();
        }
    }
    public void PauseOrResume()
    {
        if (GameUI._Button.GameUIButtons[2].activeSelf && GameUI._Button.GameUIButtons[3].activeSelf)
        {
            Time.timeScale = 1;
        }
    }

    public void WaveValue(int wave)
    {
        _waveText += wave;
        WaveText.text = _waveText.ToString();
    }
    void WaveCounter()
    {
        if (WaveSpawner.waveCountdown <= 0)
        {
            WaveValue(1);
        }
    }
    public void CoinValue(int coin)
    {
        _coinText += coin;
        CoinText.text = _coinText.ToString();
    }

    public void PaidTower(int Decrease)
    {
        _coinText -= Decrease;
        CoinText.text = _coinText.ToString();
    }

  

    public void SellTower(int value)
    {
        _coinText += value;
        CoinText.text = _coinText.ToString();
    }

    public void TowerUpgradeMoney(int Decrease)
    {
        _coinText -= Decrease;
        CoinText.text = _coinText.ToString();
    }

    public void WaveStartCoinFunction()
    {
        if (WaveSpawner.waveIndex == 0)
        {
            Product = 0;
            return;
        }

        Product = GameManager._Product;
        float count = WaveSpawner.waveCountdown * Product;
        _coinText += (int)count;
        CoinText.text = _coinText.ToString();
        Debug.Log(WaveSpawner.waveCountdown);
        Debug.Log(count);
    }

    public void Winning()
    {
        if (_waveText >= 12)
        {
            GameUI._Button.GameUIButtons[2].SetActive(true);
            GameUI._Button.GameUIButtons[9].SetActive(true);
        }
    }
}
