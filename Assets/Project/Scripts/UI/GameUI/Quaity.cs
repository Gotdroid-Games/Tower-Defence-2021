using System.Collections;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Quaity : MonoBehaviour
{


    GameUI GameUI;
    WaveSpawner WaveSpawner;
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI CoinText;

    public int _coinText = 1000;
    public int _heartText = 20;
    public int _waveText = 0;
    float Product=2;


    private void Start()
    {
        _heartText = 20;
        _waveText = 0;
        _coinText = 1000;

        GameUI = FindObjectOfType<GameUI>();
        WaveSpawner = FindObjectOfType<WaveSpawner>();
    }

    private void Update()
    {
        if (_heartText <= 0 || _waveText >= 12)
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

    //public void WaveStartCoinFunction()
    //{
    //    _coinText += WaveSpawner.WaveStartCoin;
    //    CoinText.text += _coinText.ToString(); 
    //}

    public void WaveStartCoinFunction()
    {
        float count = WaveSpawner.waveCountdown*=Product;
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

    //[SerializeField] private TextMeshProUGUI heartText;
    //[SerializeField] private TextMeshProUGUI waveText;
    //[SerializeField] private TextMeshProUGUI coinText;

    //private GameUI gameUI;
    //private WaveSpawner waveSpawner;
    //private int heartValue = 20;
    //private int waveValue = 0;
    //private int coinValue = 1000;

    //private void Start()
    //{
    //    gameUI = FindObjectOfType<GameUI>();
    //    waveSpawner = FindObjectOfType<WaveSpawner>();
    //}

    //private void Update()
    //{
    //    if (heartValue <= 0 || waveValue >= 12)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //    if (coinValue < 0)
    //    {
    //        coinValue = 0;
    //    }

    //    WaveCounter();
    //}

    //private void OnDisable()
    //{
    //    DefeatMenu();
    //    Winning();
    //}

    //private void Damage(int damage)
    //{
    //    heartValue -= damage;
    //    heartText.text = heartValue.ToString();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Damage(1);
    //        Destroy(other.gameObject);
    //    }
    //}

    //public void DefeatMenu()
    //{
    //    if (heartValue <= 0)
    //    {
    //        gameUI.DefeatMenu();
    //    }
    //}

    //public void PauseOrResume()
    //{
    //    if (gameUI._Button.GameUIButtons[2].activeSelf && gameUI._Button.GameUIButtons[3].activeSelf)
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    //public void WaveValue(int wave)
    //{
    //    waveValue += wave;
    //    waveText.text = waveValue.ToString();
    //}

    //private void WaveCounter()
    //{
    //    if (waveSpawner.countdown <= 0)
    //    {
    //        WaveValue(1);
    //    }
    //}

    //public void CoinValue(int coin)
    //{
    //    coinValue += coin;
    //    coinText.text = coinValue.ToString();
    //}

    //public void PaidTower(int decrease)
    //{
    //    coinValue -= decrease;
    //    coinText.text = coinValue.ToString();
    //}

    //public void SellTower(int value)
    //{
    //    coinValue += value;
    //    coinText.text = coinValue.ToString();
    //}

    //public void TowerUpgradeMoney(int decrease)
    //{
    //    coinValue -= decrease;
    //    coinText.text = coinValue.ToString();
    //}

    //public void Winning()
    //{
    //    if (waveValue >= 10)
    //    {
    //        gameUI._Button.GameUIButtons[2].SetActive(true);
    //        gameUI._Button.GameUIButtons[9].SetActive(true);
    //    }
    //}
}
