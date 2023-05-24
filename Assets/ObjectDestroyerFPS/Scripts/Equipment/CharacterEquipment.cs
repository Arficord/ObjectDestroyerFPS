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
        [SerializeField] private PlayerController _character;
        [SerializeField] private EquipItem[] _equipItems;
        [SerializeField] private bool _equipOnStart = true;
        [SerializeField] private int _startEquipSlotID = 0;
        
        public Action<EquipItem> onItemEquipped;
        public Action<EquipItem> onItemUnEquipped;
        
        private EquipItem _equippedItem;
        private int _equippedItemSlotID = -1;
        
        public EquipItem EquippedItem => _equippedItem;
        

        private void Awake()
        {
            InitializeItems();
        }

        private void Start()
        {
            if (_equipOnStart)
            {
                EquipItem(_startEquipSlotID);
            }
        }

        public void EquipNextItem()
        {
            var slotToEquip = _equippedItemSlotID + 1;
            if (slotToEquip >= _equipItems.Length)
            {
                slotToEquip = 0;
            }
            
            EquipItem(slotToEquip);
        }
        
        public void EquipPrevItem()
        {
            var slotToEquip = _equippedItemSlotID - 1;
            if (slotToEquip < 0)
            {
                slotToEquip = _equipItems.Length -1;
            }
            
            EquipItem(slotToEquip);
        }

        public void EquipItem(int slotID)
        {
            if (slotID < 0 || slotID >= _equipItems.Length)
            {
                Debug.LogError($"Tried to equip item, but index [{slotID}] out of range");
                return;
            }

            var itemToEquip = _equipItems[slotID];
            
            if (_equippedItem != null)
            {
                UnequipEquippedItem();
            }

            _equippedItemSlotID = slotID;
            _equippedItem = itemToEquip;
            _equippedItem.OnEquip();
            onItemEquipped?.Invoke(_equippedItem);
        }

        public void UnequipEquippedItem()
        {
            if (_equippedItem == null)
            {
                return;
            }
            
            var item = _equippedItem;
            _equippedItemSlotID = -1;
            _equippedItem = null;
            item.OnUnEquip();
            onItemUnEquipped?.Invoke(item);
        }

        private void InitializeItems()
        {
            for (int i = 0; i < _equipItems.Length; i++)
            {
                _equipItems[i].Initialize(_character);
            }
        }
    }
}