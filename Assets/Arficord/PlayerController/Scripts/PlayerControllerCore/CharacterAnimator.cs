using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arf.Player
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float movementDumping = 0.1f;

        private const string NameMovementX = "MovementX";
        private const string NameMovementZ = "MovementZ";
        private const string NameMoving = "Moving";
        private const string NameMainAbilityID= "MainAbilityID";
        private const string NameSecondaryAbilityID= "SecondaryAbilityID";

        private int _hashMovementX;
        private int _hashMovementZ;
        private int _hashMoving;
        private int _hashMainAbilityID;
        private int _hashSecondaryAbilityID;
        
        private void Awake()
        {
            _hashMovementX = Animator.StringToHash(NameMovementX);
            _hashMovementZ = Animator.StringToHash(NameMovementZ);
            _hashMoving = Animator.StringToHash(NameMoving);
            _hashMainAbilityID = Animator.StringToHash(NameMainAbilityID);
            _hashSecondaryAbilityID = Animator.StringToHash(NameSecondaryAbilityID);
        }

        public void SetMovement(Vector3 movement)
        {
            animator.SetBool(_hashMoving, movement.x != 0 || movement.z != 0);
            animator.SetFloat(_hashMovementX, movement.x, movementDumping, Time.deltaTime);
            animator.SetFloat(_hashMovementZ, movement.z, movementDumping, Time.deltaTime);
        }

        public void SetMainAbilityID(int id)
        {
            animator.SetInteger(_hashMainAbilityID, id);
        }
        
        public void SetSecondaryAbilityID(int id)
        {
            animator.SetInteger(_hashSecondaryAbilityID, id);
        }
    }
}
