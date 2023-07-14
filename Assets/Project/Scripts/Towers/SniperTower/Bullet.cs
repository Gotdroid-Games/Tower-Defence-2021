using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Bullet : MonoBehaviour
{
    GameManager GameManager;
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public AudioClip EnemyTouchSFX;
    AudioSource source;
    AudioManager audiomanager;



    public void Seek (Transform _target)
    {
        target = _target;
        
    }

    private void Start()
    {
        audiomanager = FindObjectOfType<AudioManager>();

        GameManager = FindObjectOfType<GameManager>();
        //EnemyTouchSFX = GameManager.TowerVaribles[0].EnemyTouchSFX;
        source = audiomanager.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) < 0.1f)
        {
            target.GetComponent<Enemy>().TakeDamage();
            audiomanager.PlaySFX("EnemytouchSFX");
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("deðdi");
            
    //    }
    //}
}
