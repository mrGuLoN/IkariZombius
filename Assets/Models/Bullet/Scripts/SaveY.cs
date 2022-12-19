using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveY : MonoBehaviour
{
    private Transform _thisTR;
    void Start()
    {
        _thisTR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _thisTR.position = new Vector3(_thisTR.position.x, 0, _thisTR.position.z); 
    }
}
