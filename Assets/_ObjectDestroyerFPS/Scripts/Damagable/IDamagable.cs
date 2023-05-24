using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Battling
{
    public interface IDamagable
    {
        public void TakeDamage(Damage damage);
    }
}