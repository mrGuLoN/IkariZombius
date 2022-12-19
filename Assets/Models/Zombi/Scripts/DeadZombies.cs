using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZombies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, -6);
    }
}
