using Arf.Player;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items
{
    public class EquipItem : MonoBehaviour
    {
        public PlayerController Character => _characterController;
        
        protected PlayerController _characterController;
        
        public virtual void Initialize(PlayerController character)
        {
            _characterController = character;
            ShowModel(false);
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
    }
}

