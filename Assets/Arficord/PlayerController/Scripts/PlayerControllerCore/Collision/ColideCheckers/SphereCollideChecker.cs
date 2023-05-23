using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollideChecker : CollideChecker
{
    public float radius = 1f;

    protected override int GetColliders()
    {
        return Physics.OverlapSphereNonAlloc(transform.position, radius, _colliders, mask, triggerInteraction);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.4f, 0,0.7f, 0.2f);
        Gizmos.DrawSphere(transform.position, radius);
    }
    #endif
}
