using System;
using UnityEngine;

[Serializable]
public class SlowWalkingStateConfig
{
    [field: SerializeField, Range(0, 5)] public float Speed { get; private set; }
}
