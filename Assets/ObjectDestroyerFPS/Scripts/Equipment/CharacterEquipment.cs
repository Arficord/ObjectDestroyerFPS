using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment
{
    public class CharacterEquipment : MonoBehaviour
    {
        [Serializable]
        public class EquipmentSlot
        {
            [SerializeField] private Transform placeTransform;
            
            public Transform PlaceTransform => placeTransform;
        }

        public EquipmentSlot[] _euipmentSlots;
    }
}