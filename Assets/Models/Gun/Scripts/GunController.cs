using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private PollerObject.ObjectInfo.ObjectType bullet;
    [SerializeField] private float damage, speedBullet;
    [SerializeField] private int magazine, ammo;
    [SerializeField] private AudioSource reloadSound;

    public delegate void AmmoHUD(int magazine, int allAmmo);
    public static event AmmoHUD _ammoHud;

    private GameObject _bullet;
    private AudioSource _audioFire;
    private Animator _ani;
    private int _currentAmmoInMagazine;

    void Start()
    {
        _audioFire = GetComponent<AudioSource>();
        _ani = GetComponent<Animator>();
        _currentAmmoInMagazine = magazine;
        _ammoHud(_currentAmmoInMagazine, ammo);
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
        _currentAmmoInMagazine--;
        if (_currentAmmoInMagazine <= 0)
        {
            _ani.SetTrigger("Reload");
        }
        _ammoHud(_currentAmmoInMagazine, ammo);
    }

    public void Reload()
    {
        if (ammo > 0)
        {
            int needAmmo = magazine - _currentAmmoInMagazine;
            if (needAmmo >= magazine) needAmmo = magazine;
            if (ammo >= magazine) _currentAmmoInMagazine = magazine;
            else _currentAmmoInMagazine = ammo;
            ammo -= needAmmo;
        }
        else ammo = 0;
        _ammoHud(_currentAmmoInMagazine, ammo);
    }

    public void ReloadSound()
    {
        reloadSound.Play();
    }

    public void UpDateAmmo(int intMagazine)
    {
        ammo += magazine * intMagazine;
        _ammoHud(_currentAmmoInMagazine, ammo);
    }
}
