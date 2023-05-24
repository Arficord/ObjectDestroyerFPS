using Arf.Player;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items
{
    public class EquipItem : MonoBehaviour
    {
        [SerializeField] private int equipSlotID = 0;
        
        public PlayerController Character => _characterController;
        
        protected PlayerController _characterController;
        protected Transform _transform;
        
        public virtual void Initialize(PlayerController character)
        {
            _transform = transform;
            _characterController = character;
            ShowModel(false);
            MoveObjectUnderSlot(equipSlotID);
        }
        
        public virtual void OnEquip()
        {
            ShowModel(true);
        }
        
        public virtual void OnUnEquip()
        {
            ShowModel(false);
        }
        
        private void ShowModel(bool flag)
        {
            gameObject.SetActive(flag);
        }

        private void MoveObjectUnderSlot(int slotID)
        {
            var slots = _characterController.CameraController.GetComponentsInChildren<EquipmentSlot>();

            for (int i = 0; i < slots.Length; i++)
            {
                var equipmentSlot = slots[i];
                
                if (equipmentSlot.SlotID == slotID)
                {
                    _transform.SetParent(equipmentSlot.transform);
                    _transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                    return;
                }
            }
        }
    }
}

