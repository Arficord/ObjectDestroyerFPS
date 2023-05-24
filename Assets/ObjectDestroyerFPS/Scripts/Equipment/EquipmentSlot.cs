using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment
{
    public class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] private int slotID;
        
        public int SlotID => slotID;
    }
}