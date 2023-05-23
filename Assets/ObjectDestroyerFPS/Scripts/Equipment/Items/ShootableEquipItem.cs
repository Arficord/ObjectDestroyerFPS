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

        //TODO: delete. this test method
        private void Awake()
        {
            _shootModule = new RaycastModule();
            _impactModule = new MaterialDamageModule(); 
        }

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
        }

        private void InitializeModules()
        {
            _shootModule.Initialize(this);
            _impactModule.Initialize(this);
        }
    }
}