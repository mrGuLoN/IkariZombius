using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private int healthUp;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().HealthUp(healthUp);
        Destroy(this.gameObject);
    }
}
