using System;
using System.Collections;
using System.Collections.Generic;
using Arf.Player;
using ObjectDestroyerFPS.Equipment.Items;
using ObjectDestroyerFPS.Equipment.Items.Modules;
using ObjectDestroyerFPS.Equipment.Items.Utils;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items
{
    public class ShootableEquipItem : UsableEquipItem
    {
        [SerializeReference] private ShootModule _shootModule;
        [SerializeReference] private ImpactModule _impactModule;
        //NOTE: it's better to use one array for _impactModule and _effectModule.
        //But currently have no time to write separate inspector for it
        [SerializeReference] private ImpactModule _impactEffectModule;
        
        public override void Initialize(PlayerController character)
        {
            base.Initialize(character);
            InitializeModules();
        }

        public override void Use()
        {
            base.Use();
            _shootModule.ProceedShoot();
        }

        public void ProceedImpact(HitInfo hitInfo)
        {
            _impactModule.ProceedImpact(hitInfo);
            _impactEffectModule.ProceedImpact(hitInfo);
        }

        private void InitializeModules()
        {
            _shootModule.Initialize(this);
            _impactModule.Initialize(this);
            _impactEffectModule.Initialize(this);
        }
    }
}