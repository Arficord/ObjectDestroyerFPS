using System.Collections;
using System.Collections.Generic;
using Arf.Player;
using ObjectDestroyerFPS.Equipment.Items.Modules;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items
{
    public class UsableEquipItem : EquipItem
    {
        public override void Initialize(PlayerController character)
        {
            base.Initialize(character);
        }

        public virtual void Use()
        {
            
        }
    }
}