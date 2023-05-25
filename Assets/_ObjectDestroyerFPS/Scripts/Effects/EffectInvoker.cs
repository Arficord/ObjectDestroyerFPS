using System.Collections;
using System.Collections.Generic;
using Arf.Effects;
using UnityEngine;

namespace ObjectDestroyerFPS.Effects
{
    public class EffectInvoker : MonoBehaviour
    {
        public void SpawnEffect(EffectData effectData)
        {
            var transformCash = transform;
            EffectsManager.Instance.SpawnEffect(effectData, transformCash.position, transformCash.rotation);
        }
    }
}