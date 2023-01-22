using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodmoved : MonoBehaviour
{
    private Transform _thisTR;
    // Start is called before the first frame update
    void Start()
    {
        _thisTR = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _thisTR.position -= Vector3.forward * 5 * Time.deltaTime;
    }
}
