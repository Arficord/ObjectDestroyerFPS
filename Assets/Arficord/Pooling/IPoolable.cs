using System.Collections;
using System.Collections.Generic;
using Arf.Pooling.Interfaces;
using UnityEngine;

namespace Arf.Pooling.Interfaces
{
    public interface IPoolable
    {
        public void InitializeByPool(IPool pool);

        public IPoolable CreateNewInstance();
        public void SetTransformProperties(Vector3 position, Quaternion rotation, Transform parent);

        public void OnTakeFromPool();
        public void OnReleaseFromPool();
        
        public void OnDestroyFromPool();
    }
}
