using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Materials;
using UnityEngine;

namespace ObjectDestroyerFPS.Battling
{
    public class Damage
    {
        public float Value { get; private set; }
        public MaterialData Material { get; private set; }

        public Damage(float value, MaterialData material)
        {
            SetData(value, material);
        }
        
        public void SetData(float value, MaterialData material)
        {
            Value = value;
            Material = material;
        }
    }
}