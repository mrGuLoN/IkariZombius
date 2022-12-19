using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInitiateObj : MonoBehaviour
{
    public PollerObject.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PollerObject.ObjectInfo.ObjectType type;
}
