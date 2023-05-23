using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arf.Player.Abilities
{
    public class FallAbility : Ability
    {
        public override bool CanStartAbility()
        {
            return !_playerController.Grounded && _playerController.Velocity.y < 0;
        }
    }
}
