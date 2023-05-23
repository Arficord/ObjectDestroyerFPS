using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollideChecker : MonoBehaviour
{
    public Action<int, Collider[]> onCheck;
    [SerializeField] protected LayerMask mask;
    [SerializeField] protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

    protected Collider[] _colliders = new Collider[5];
    protected Coroutine _checkingCoroutine;

    protected IEnumerator Checking() 
    {
        while (true)
        {
            int collisions = GetColliders();
            onCheck(collisions, _colliders);
            yield return new WaitForFixedUpdate();
        }
    }

    protected abstract int GetColliders();
    
    public void Activate()
    {
        if (_checkingCoroutine != null)
        {
            StopCoroutine(_checkingCoroutine);
        }
        _checkingCoroutine = StartCoroutine(Checking());
    }
    public void Deactivate()
    {
        StopCoroutine(_checkingCoroutine);
    }
}
