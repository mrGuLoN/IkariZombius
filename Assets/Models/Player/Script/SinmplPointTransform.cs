using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinmplPointTransform : MonoBehaviour
{
    [SerializeField] private Transform rightArm;

    private Transform _thisTR;
    private Vector3 _distance;
    private void Start()
    {
        _thisTR = GetComponent<Transform>();
        _distance = rightArm.position - _thisTR.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _thisTR.position = rightArm.position - _distance;
    }
}
