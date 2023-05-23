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
        }
        
        public virtual void OnEquip()
        {
            
        }
        
        public virtual void OnUnEquip()
        {
            
        }
    }
}

