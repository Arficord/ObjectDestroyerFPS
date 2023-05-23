using System;
using System.Collections;
using System.Collections.Generic;
using ObjectDestroyerFPS.Equipment.Items.Utils;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Modules
{
    public class RaycastModule : ShootModule
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float distance = 30;
        [SerializeField] private QueryTriggerInteraction triggerDetection;
        [SerializeField] [Min(1)] private int maxTargetsAmout = 1;

        protected ShootableEquipItem _shootableItem;
        protected RaycastHit[] _raycastHits;
        protected HitInfo _hitInfo;

        public override void Initialize(EquipItem item)
        {
            base.Initialize(item);
            _shootableItem = (ShootableEquipItem) item;
            
            _raycastHits = new RaycastHit[maxTargetsAmout];
            _hitInfo = new HitInfo();
        }

        public override void ProceedShoot()
        {
            var lookDirection = _item.Character.CameraController.GetLookDirection();
            var size = Physics.RaycastNonAlloc(shootPoint.position, lookDirection, _raycastHits, distance, layerMask, triggerDetection);

            for (int i = 0; i < size; i++)
            {
                var raycastHit = _raycastHits[i];
                _hitInfo.SetData(raycastHit);
                _shootableItem.ProceedImpact(_hitInfo);
            }
        }
    }
}