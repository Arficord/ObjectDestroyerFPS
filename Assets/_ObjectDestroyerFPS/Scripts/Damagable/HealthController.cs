using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Battling;
using ObjectDestroyerFPS.Materials;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health;
    [SerializeField] private MaterialData _material;
    [SerializeField] private UnityEvent _onDieEvent;

    public float Health => _health;
    public MaterialData Material => _material;

    public void TakeDamage(Damage damage)
    {
        if (damage.Material != _material)
        {
            Debug.Log($"Tried to inflict [{damage.Material}] damage to [{gameObject.name}]. But this object uses [{_material.MaterialName}] material.");
            return;
        }
        
        Debug.Log($"Object [{gameObject.name}] takes [{damage.Value}] damage.");
        _health -= damage.Value;
        CheckHealth();
    }
    
    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _onDieEvent?.Invoke();
    }
}
