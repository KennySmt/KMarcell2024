using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] RangedTargetProvider targetProvider;
    protected Agent Target => targetProvider.Target;

    protected virtual void Update()
    {
        ChildUpdate();
    }

    protected virtual void ChildUpdate() { }
}
