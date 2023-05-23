using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Equipment.Items.Utils;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public abstract class ImpactModule : EquipItemModule
    {
        public abstract void ProceedImpact(HitInfo hitInfo);
    }
}