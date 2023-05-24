using Arf.Effects;
using ObjectDestroyerFPS.Equipment.Items.Utils;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public class ImpactEffectModule : ImpactModule
    {
        [SerializeField] private EffectData _hitEffect;

        public override void ProceedImpact(HitInfo hitInfo)
        {
            EffectsManager.Instance.SpawnEffect(_hitEffect, hitInfo.Point, Quaternion.LookRotation(hitInfo.Normal));
        }
    }
}