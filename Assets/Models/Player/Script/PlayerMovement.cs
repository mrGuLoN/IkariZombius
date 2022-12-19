using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Movement(float x, float z)
    {
        x = x * Time.deltaTime;
        z = z * Time.deltaTime;
        _characterController.Move(new Vector3(x, -1f, z));
    }
}
