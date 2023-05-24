using System.Collections.Generic;
using Arf.Pooling;
using Arf.Pooling.Interfaces;
using UnityEngine;

namespace Arf.Effects
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogWarning($"{nameof(EffectsManager)} has no {nameof(Instance)} assigned but received call");
                    _instance = FindObjectOfType<EffectsManager>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private static EffectsManager _instance;

        private readonly Dictionary<EffectData, ItemsPool> _effectPools = new Dictionary<EffectData, ItemsPool>(); 
        
        private void Awake()
        {
            _instance = this;
        }

        public void SpawnEffect(EffectData effectData, Vector3 position, Quaternion rotation)
        {
            var effectPrefab = effectData.EffectPrefab;
            
            if (effectPrefab == null)
            {
                Debug.LogError("Tried to spawn effect, but effect data has no effect prefab.");
                return;
            }
            
            if (!effectData.UsePool)
            {
                Instantiate(effectPrefab, position, rotation, transform);
                return;
            }

            var pool = GetPool(effectData);
            pool.TakeFromPool(position, rotation, transform);
        }

        private ItemsPool GetPool(EffectData effectData)
        {
            if (!_effectPools.TryGetValue(effectData, out var pool))
            {
                IPoolable poolableComponent = effectData.EffectPrefab.GetComponent<IPoolable>();
                if (poolableComponent == null)
                {
                    Debug.LogError($"Effected marked as poolable, but has no component which implement {nameof(IPoolable)} interface");
                    return null;
                }
                pool = new ItemsPool(poolableComponent);
                _effectPools.Add(effectData, pool);
            }
            
            return pool;
        }
    }
}
