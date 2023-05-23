using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public abstract class ShootModule: EquipItemModule
    {
        public abstract void ProceedShoot();
    }
}