using UnityEngine;

namespace Arf.Effects
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "Arficord/Effects/EffectData", order = 1)]
    public class EffectData : ScriptableObject
    {
        //WIP Add sound support
        
        [SerializeField] private bool usePool = true;
        [SerializeField] private GameObject effectPrefab;
        
        public bool UsePool => usePool;
        public GameObject EffectPrefab => effectPrefab;
    }
}
