using UnityEngine;
using DG.Tweening;

public class Bombbullet : MonoBehaviour
{
    GameManager GameManager;
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public AudioClip EnemyTouchSFX;
    AudioSource source;

    float Sin;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        EnemyTouchSFX = GameManager.TowerVaribles[0].EnemyTouchSFX;
        source = GameManager.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.position.y <= target.position.y)
        {
            Explode();
        }
            
    }

    public void Explode()
    {

        for (int i = 0; i < GameManager.Instance.ActiveRobots.Length; i++)
        {
            if (GameManager.Instance.ActiveRobots[i] != null && Vector3.Distance(GameManager.Instance.ActiveRobots[i].transform.position, this.transform.position) < GameManager.bombTowerExplosionRadius)
            {
                GameManager.Instance.ActiveRobots[i].GetComponent<Enemy>().TakeDamage();
            }
        }

        source.clip = GameManager.TowerVaribles[0].EnemyTouchSFX;
        source.Play();

        Destroy(gameObject);
    }
}
