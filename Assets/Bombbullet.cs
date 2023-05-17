using UnityEngine;

public class Bombbullet : MonoBehaviour
{
    GameManager GameManager;
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public AudioClip EnemyTouchSFX;
    AudioSource source;

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

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) < 0.1f)
        {
            if (explosionRadius > 0f)
            {
                Explode();
            }
            else
            {
                HitTarget();
            }
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().TakeDamage();
            }
        }

        Destroy(gameObject);
    }

    private void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            source.clip = GameManager.TowerVaribles[0].EnemyTouchSFX;
            source.Play();
        }
    }
}
