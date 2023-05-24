using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public class EquipItemModule
    {
        protected EquipItem _item;
        
        public virtual void Initialize(EquipItem item)
        {
            _item = item;
        }
    }
}