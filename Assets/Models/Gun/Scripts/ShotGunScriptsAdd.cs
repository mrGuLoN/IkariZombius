using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScriptsAdd : MonoBehaviour
{
    [SerializeField] private AudioSource addOneAmmo;

    public void AddOneAmmoSound()
    {
        addOneAmmo.Play();
    }
}
