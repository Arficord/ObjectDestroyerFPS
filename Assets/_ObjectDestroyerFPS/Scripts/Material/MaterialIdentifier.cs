using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Materials;
using UnityEngine;

namespace ObjectDestroyerFPS.Materials
{
    public class MaterialIdentifier : MonoBehaviour
    {
        [SerializeField] private MaterialData _materialData;

        public MaterialData GetMaterialData()
        {
            return _materialData;
        }
    }
}