using System.Collections;
using System.Collections.Generic;
using Arf.Player.Abilities;
using ObjectDestroyerFPS.Equipment;
using UnityEngine;

namespace ObjectDestroyerFPS.Player.Abilities
{
    public class EquipItemAbility : Ability
    {
        [SerializeField] private CharacterEquipment _equipment;

        private int _equipSlot = 0;
        
        public override bool CanInputStartAbility(InputContainer input)
        {
            if (input.equip0ButtonPress)
            {
                _equipSlot = 0;
                return true;
            }
            if (input.equip1ButtonPress)
            {
                _equipSlot = 1;
                return true;
            }
            if (input.equip2ButtonPress)
            {
                _equipSlot = 2;
                return true;
            }
            
            return false;
        }

        protected override void OnAbilityStarted()
        {
            _equipment.EquipItem(_equipSlot);
        }
    }
}