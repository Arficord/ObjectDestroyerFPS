using UnityEngine;


namespace ObjectDestroyerFPS.Materials
{
    [CreateAssetMenu(fileName = "MaterialData", menuName = "ObjectDestroyerFPS/MaterialData")]
    public class MaterialData : ScriptableObject
    {
        [SerializeField] private string materialName;
        
        public string MaterialName => materialName;
    }
}