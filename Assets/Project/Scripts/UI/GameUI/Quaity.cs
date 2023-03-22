using System.Collections;
using UnityEngine;
using TMPro;

public class Quaity : MonoBehaviour
{
    public static Quaity Instance;
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI CoinText;
    
    public int _coinText = 1000;
    public int _heartText = 20;
    public int _waveText = 0;
    
    //public bool CoinControl;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _heartText = 20;
        _waveText = 0;
        _coinText = 1000;
    }

    private void Update()
    {
        if (_heartText <= 0 || _waveText >= 1)
        {
            gameObject.SetActive(false);
        }

        if (_coinText<=0)
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

    public void PaidTower(int Decrease)
    {
        _coinText-=Decrease;
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

    public void Winning()
    {
        if(_waveText>=1)
        {
            GameUI.Instance._Button.GameUIButtons[2].SetActive(true);
            GameUI.Instance._Button.GameUIButtons[9].SetActive(true);
        } 
    }
}
