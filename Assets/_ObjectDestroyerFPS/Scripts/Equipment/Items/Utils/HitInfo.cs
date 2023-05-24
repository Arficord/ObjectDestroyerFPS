using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectDestroyerFPS.Equipment.Items.Utils
{
    public class HitInfo
    {
        private Vector3 _point;
        private Vector3 _normal;
        private Collider _targetCollider;
        
        public Vector3 Point => _point;
        public Vector3 Normal => _normal;
        public Collider TargetCollider => _targetCollider;

        public HitInfo()
        {
            
        }
        
        public HitInfo(Vector3 point, Vector3 normal, Collider collider)
        {
            _point = point;
            _normal = normal;
            _targetCollider = collider;
        }
        
        public HitInfo(RaycastHit raycastHit)
        {
            SetData(raycastHit);
        }

        public void SetData(RaycastHit raycastHit)
        {
            _point = raycastHit.point;
            _normal = raycastHit.normal;
            _targetCollider = raycastHit.collider;
        }
    }
}