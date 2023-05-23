using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Battling;
using ObjectDestroyerFPS.Equipment.Items.Modules;
using ObjectDestroyerFPS.Equipment.Items.Utils;
using ObjectDestroyerFPS.Materials;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public class MaterialDamageModule : ImpactModule
    {
        [SerializeField] private float _damageValue;
        [SerializeField] private MaterialData _material;

        private Damage _damage;

        public override void Initialize(EquipItem item)
        {
            base.Initialize(item);
            
            _damage = new Damage(_damageValue, _material);
        }

        public override void ProceedImpact(HitInfo hitInfo)
        {
            if (hitInfo.TargetCollider == null)
            {
                Debug.Log("Hit info do not contain collider reference");
                return;
            }

            var damagable = hitInfo.TargetCollider.GetComponentInParent<IDamagable>();
            if (damagable == null)
            {
                Debug.Log($"Hit info do not contain IDamagable component on target [{hitInfo.TargetCollider.gameObject.name}]");
                return;
            }
            
            damagable.TakeDamage(_damage);
        }
    }
}