using System;
using System.Collections.Generic;
using Arf.Environment.Statics;
using Arf.Player.Abilities;
using UnityEngine;

namespace Arf.Player
{
    public class PlayerController : MonoBehaviour, IInputReceiver
    {
        public class StayOnInfo
        {
            private int _amount = 0;
            private Collider[] _colliders;

            public void SetInfo(int amount, Collider[] colliders)
            {
                _amount = amount;
                _colliders = colliders;
            }

            public bool HasCollider(Collider collider)
            {
                for (int i = 0; i < _amount; i++)
                {
                    if (_colliders[i] == collider)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        
        [SerializeField] private CharacterLocomotion characterLocomotion;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private float gravity = 9.81f;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private float walkSpeed = 3f;
        [SerializeField] private float runSpeed = 15f;

        [SerializeField] private float onGroundYVelocity = -0.01f;

        [SerializeField] private CollideChecker colideChecker;

        [SerializeReference] private List<Ability> _abilities;

        public bool Grounded
        {
            get => grounded;
            
            private set
            {
                if (grounded == value)
                {
                    return;
                }

                grounded = value;
                OnGroundedChanged?.Invoke(grounded);
            }
        }
        public Vector3 Velocity => _velocity;
        public Vector3 MoveVelocityInput => _moveVelocityInput;
        public MovingPlatform MovingPlatformRef => _movingPlatform;

        public StayOnInfo StayOnGroundInfo { get; private set; } = new StayOnInfo();

        [NonSerialized]
        public Action<bool> OnGroundedChanged;
        
        private Vector3 _velocity;
        private Vector3 _moveVelocityInput;
        private Transform _transform;

        private MovingPlatform _movingPlatform;

        private bool grounded = true;

        private void Awake()
        {
            //controller.detectCollisions = false;
            
            _transform = transform;
            colideChecker.onCheck += OnGroundCheckerUpdate;
            colideChecker.Activate();
            
            foreach (var ability in _abilities)
            {
                ability.Initialize(this);
            }
        }

        private void FixedUpdate()
        {
            var movingPlatformVelocity = _movingPlatform != null ? _movingPlatform.GetRigidbody.velocity : Vector3.zero;
            if (movingPlatformVelocity.y > 0)
            {
                movingPlatformVelocity.y = onGroundYVelocity;                
            }

            ApplyGravity();
            var velocity = _velocity + movingPlatformVelocity + _moveVelocityInput;
            characterLocomotion.Velocity = velocity;
        }
        

        private void UpdateAbilities(InputContainer input)
        {
            // Update and try to disable abilities
            foreach (var ability in _abilities)
            {
                if (!ability.Active)
                {
                    continue;
                }

                ability.InputUpdate(input);
                ability.TryStopAbility(input);
                
                if (!ability.Active)
                {
                    UpdateAbilityAnimation(ability);
                }
            }
            
            //TODO: use a separate list for active abilities. Performs up
            // Try to start abilities
            foreach (var ability in _abilities)
            {
                if (ability.Active)
                {
                    continue;
                }
                ability.TryStartAbility(input);

                if (ability.Active)
                {
                    UpdateAbilityAnimation(ability);
                }
            }
        }

        private void UpdateAbilityAnimation(Ability ability)
        {
            if (ability.AnimatorMainID != -1)
            {
                characterAnimator.SetMainAbilityID(ability.Active? ability.AnimatorMainID : 0);
            }
            if (ability.AnimatorSecondaryID != -1)
            {
                characterAnimator.SetSecondaryAbilityID(ability.Active? ability.AnimatorSecondaryID : 0);
            }
        }

        public void DoInput(InputContainer input)
        {
            UpdateAbilities(input);
            
            Move(input.moveAxis, input.runButtonHold);
            cameraController.ClampRotate(input.mouseAxis.y * Time.deltaTime);
            _transform.Rotate(Vector3.up * (input.mouseAxis.x * Time.deltaTime));
        }

        public T GetAbility<T>() where T : Ability
        {
            foreach (var ability in _abilities)
            {
                if (ability is T abilityOfType)
                {
                    return abilityOfType;
                }
            }

            return null;
        }

        public void SetVelocity(Vector3 velocity)
        {
            if (velocity.y > 0)
            {
                _movingPlatform = null;
                Grounded = false;
            }
            _velocity = velocity;
        }

        private void Move(Vector2 movement, bool running)
        {
            var normalizedMovement = movement.normalized;
            _moveVelocityInput = (_transform.right * normalizedMovement.x + _transform.forward * normalizedMovement.y);
            _moveVelocityInput *= running ? runSpeed : walkSpeed;
            characterAnimator.SetMovement(new Vector3(normalizedMovement.x, 0, normalizedMovement.y) * (running ? 2 : 1));
        }

        private void ApplyGravity()
        {
            if (!Grounded)
            {
                _velocity.y -= gravity * Time.fixedDeltaTime;
            }
        }

        private void OnGroundCheckerUpdate(int collisions, Collider[] colliders)
        {
            _movingPlatform = null;
            StayOnGroundInfo.SetInfo(collisions, colliders);

            if (collisions == 0)
            {
                Grounded = false;
                return;
            }
            
            var maxVelocity = onGroundYVelocity;
            
            for (int i = 0; i < collisions; i++)
            {
                float velocityY;
                if (colliders[i].TryGetComponent(out Rigidbody colliderRigidbody))
                {
                    velocityY = colliderRigidbody.velocity.y;
                    _movingPlatform = colliderRigidbody.GetComponent<MovingPlatform>();
                }
                else
                {
                    velocityY = onGroundYVelocity;
                }

                if (velocityY > maxVelocity)
                {
                    maxVelocity = velocityY;
                }
            }

            Grounded = maxVelocity >= onGroundYVelocity;
            _velocity.y = maxVelocity;   
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}
