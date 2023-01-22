using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigPointTransform : MonoBehaviour
{
    [SerializeField] private Transform gunRigPoint;
    private Transform _thisTransform;
    void Start()
    {
        _thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _thisTransform.position = gunRigPoint.position;
        _thisTransform.rotation = gunRigPoint.rotation;
    }
}
