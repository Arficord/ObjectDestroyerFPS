using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arf.Player
{
    public class CharacterLocomotion : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbodyComponent;

        public Vector3 Velocity
        {
            get => rigidbodyComponent.velocity;
            set => rigidbodyComponent.velocity = value;
        }
    }
}
