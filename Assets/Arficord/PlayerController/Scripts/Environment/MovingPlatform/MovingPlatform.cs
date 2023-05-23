using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arf.Environment.Statics
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbodyComponent;

        public Rigidbody GetRigidbody => rigidbodyComponent;

        private void Awake()
        {
            rigidbodyComponent ??= GetComponent<Rigidbody>();
        }
    }
}
