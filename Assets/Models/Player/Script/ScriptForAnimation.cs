using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource[] step;

    public void SoundStep()
    {
        int i = Random.Range(0, step.Length);
        step[i].Play();
    }
}
