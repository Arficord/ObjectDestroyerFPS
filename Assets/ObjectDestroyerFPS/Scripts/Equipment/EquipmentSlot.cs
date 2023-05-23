using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment
{
    public class EquipmentSlot
    {
        [SerializeField] private Transform placeTransform;

        public Transform PlaceTransform => placeTransform;
    }
}