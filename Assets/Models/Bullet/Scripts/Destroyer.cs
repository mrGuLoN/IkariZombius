using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Rigidbody _rb;
    public void StartDestroyer()
    {
        _rb = GetComponent<Rigidbody>();
        Debug.Log("Time to blood Lalalalululu");
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        _rb.velocity = Vector3.zero;
        Debug.Log("Time to blood destroy");
        PollerObject.Instance.DestroyGameObject(this.gameObject); 
    }
}
