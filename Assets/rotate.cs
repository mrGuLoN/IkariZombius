using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private Transform tr;
    private float z;
    void Start()
    {
        tr = GetComponent<Transform>();
        z = Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(new Vector3(z, z, z) * Time.deltaTime);
    }
}
