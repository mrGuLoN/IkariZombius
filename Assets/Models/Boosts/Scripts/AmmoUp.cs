using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUp : MonoBehaviour
{
    [SerializeField] private int minMagazine, maxMagazine;

    private int _magazine;
    void Start()
    {
        _magazine = Random.Range(minMagazine, maxMagazine);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().UpDateAmmo(_magazine);
        Destroy(this.gameObject);
    }
}
