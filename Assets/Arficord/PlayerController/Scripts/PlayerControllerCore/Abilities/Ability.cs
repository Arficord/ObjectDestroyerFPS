using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Arf.Player.Abilities
{
    [Serializable]
    public class Ability
    {
        [SerializeField] protected int animatorMainID = -1;
        [SerializeField] protected int animatorSecondaryID = -1;

        public int AnimatorMainID => animatorMainID;
        public int AnimatorSecondaryID => animatorSecondaryID;
        
        public bool Active { get; set; }

        protected PlayerController _playerController;

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            Awake();
        }

        protected virtual void Awake()
        {
            
        }

        public void TryStartAbility(InputContainer input)
        {
            if (!CanInputStartAbility(input))
            {
                return;
            }

            TryStartAbility();
        }

        public void TryStartAbility()
        {
            if (!CanStartAbility())
            {
                return;
            }

            StartAbility();
        }

        protected void StartAbility()
        {
            Active = true;
            OnAbilityStarted();
        }

        public void TryStopAbility(InputContainer input)
        {
            if (!CanInputStopAbility(input))
            {
                return;
            }

            TryStopAbility();
        }

        public void TryStopAbility()
        {
            if (!CanStopAbility())
            {
                return;
            }

            StopAbility();
        }

        protected void StopAbility()
        {
            Active = false;
            OnAbilityStopped();
        }

        public virtual void InputUpdate(InputContainer input)
        {

        }

        public virtual bool CanInputStartAbility(InputContainer input)
        {
            return true;
        }

        public virtual bool CanStartAbility()
        {
            return true;
        }

        public virtual bool CanInputStopAbility(InputContainer input)
        {
            return true;
        }

        public virtual bool CanStopAbility()
        {
            return true;
        }

        protected virtual void OnAbilityStarted()
        {

        }

        protected virtual void OnAbilityStopped()
        {

        }
    }
}
