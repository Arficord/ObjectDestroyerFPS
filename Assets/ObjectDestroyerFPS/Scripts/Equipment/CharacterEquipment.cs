using System;
using System.Collections;
using System.Collections.Generic;
using Arf.Player;
using ObjectDestroyerFPS.Equipment.Items;
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

        [SerializeField] private EquipmentSlot[] _euipmentSlots;

        [SerializeField] private UsableEquipItem _usableEquipItem;

        private void Awake()
        {
            _usableEquipItem.Initialize(GetComponent<PlayerController>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _usableEquipItem.Use();
            }
        }
    }
}