using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private PollerObject.ObjectInfo.ObjectType bullet;
    [SerializeField] private float damage, speedBullet;

    private GameObject _bullet;
    private AudioSource _audioFire;

    void Start()
    {
        _audioFire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {       
        _bullet = PollerObject.Instance.GetObject(bullet);
        _audioFire.Play();
        _bullet.transform.position = firePoint.position;
        _bullet.transform.rotation = firePoint.rotation;        
        _bullet.transform.forward = -1*firePoint.forward;
        _bullet.GetComponent<BulletController>().UpDateData(damage, speedBullet, firePoint.position);
    }
}
