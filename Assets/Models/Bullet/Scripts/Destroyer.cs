using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Rigidbody _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        _rb.velocity = Vector3.zero;
        PollerObject.Instance.DestroyGameObject(this.gameObject); 
    }
}
