using System.Collections;
using System.Collections.Generic;
using Arf.Player.Abilities;
using UnityEngine;

namespace Arf.Player.Abilities
{
    public class JumpAbility : Ability
    {
        [SerializeField] private CollideChecker groundCollideChecker;
        [SerializeField] private float jumpStrength = 4;
        [SerializeField] private float coyoteTime = 0.1f;

        private float _jumpTimeDeadLine = -1;
        
        protected override void Awake()
        {
            _playerController.OnGroundedChanged += OnGroundedChanged;
        }

        public override bool CanInputStartAbility(InputContainer input)
        {
            return input.jumpButtonPressed;
        }

        public override bool CanStartAbility()
        {
            return _playerController.Grounded || _jumpTimeDeadLine > Time.time;
        }

        public override bool CanStopAbility()
        {
            return _playerController.Velocity.y < 0;
        }

        protected override void OnAbilityStarted()
        {
            groundCollideChecker.Deactivate();
            var velocity = _playerController.Velocity;
            var velocityY = Mathf.Max(velocity.y, jumpStrength);
            _playerController.SetVelocity(new Vector3(velocity.x, velocityY, velocity.z));
        }

        protected override void OnAbilityStopped()
        {
            groundCollideChecker.Activate();
        }

        protected void OnGroundedChanged(bool flag)
        {
            _jumpTimeDeadLine = flag? -1 : Time.time + coyoteTime;
        }
    }
}
