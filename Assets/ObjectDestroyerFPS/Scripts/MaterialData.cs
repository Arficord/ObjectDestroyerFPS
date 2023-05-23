using UnityEngine;


namespace TestTask.Materials
{
    [CreateAssetMenu(fileName = "MaterialData", menuName = "ObjectDestroyerFPS/MaterialData")]
    public class MaterialData : ScriptableObject
    {
        [SerializeField] private string _materialName;
        
        public string MaterialName => _materialName;
    }
}