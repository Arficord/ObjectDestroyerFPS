using System.Collections;
using System.Collections.Generic;
using Arf.Player.Abilities;
using ObjectDestroyerFPS.Equipment;
using ObjectDestroyerFPS.Equipment.Items;
using UnityEngine;

namespace ObjectDestroyerFPS.Player.Abilities
{
    public class UseItemAbility : Ability
    {
        [SerializeField] private CharacterEquipment _equipment;

        private UsableEquipItem equippedItem;
        
        protected override void Awake()
        {
            _equipment.onItemEquipped += OnItemEquip;
            _equipment.onItemUnEquipped += OnItemUnEquip;
        }

        public override bool CanStopAbility()
        {
            return equippedItem != null;
        }

        public override bool CanInputStartAbility(InputContainer input)
        {
            return input.shootButtonPressed;
        }

        protected override void OnAbilityStarted()
        {
            equippedItem.Use();
        }

        private void OnItemEquip(EquipItem item)
        {
            equippedItem = item as UsableEquipItem;
        }
        
        private void OnItemUnEquip(EquipItem item)
        {
            equippedItem = null;
        }
    }
}