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
    AudioManager audiomanager;
    float Sin;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        audiomanager = FindObjectOfType<AudioManager>();
        //EnemyTouchSFX = GameManager.TowerVaribles[0].EnemyTouchSFX;
        source = audiomanager.GetComponent<AudioSource>();
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

        audiomanager.PlaySFX("bombadusmeSFX");

        Destroy(gameObject);
    }
}
