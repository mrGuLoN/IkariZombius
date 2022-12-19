using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnContainerController : MonoBehaviour
{
    [SerializeField] private GameObject[] container;
   
    private Transform _thisTransform;
    private Quaternion _rot;

    private void Start()
    {
        _thisTransform = GetComponent<Transform>();
        int i = Random.Range(0, container.Length);
        _rot = _thisTransform.rotation;
        _rot.y += Random.RandomRange(0, 6.28f);
        Instantiate(container[i], _thisTransform.position, _rot, _thisTransform);
    }
}
