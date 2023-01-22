using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{ 

    private Animator _animator;
   
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();       
    }

    public void IdleMove(float loockX, float loockZ)
    {       
        _animator.SetFloat("LoockX", loockX);
        _animator.SetFloat("LoockZ", loockZ);
    }

    public void Move(float loockX, float loockZ)
    {       
        _animator.SetFloat("LoockX", loockX);
        _animator.SetFloat("LoockZ", loockZ);
    }


}
