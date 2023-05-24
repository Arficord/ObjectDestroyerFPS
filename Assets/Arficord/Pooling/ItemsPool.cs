using System.Collections;
using System.Collections.Generic;
using Arf.Pooling.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Arf.Pooling
{
    public class ItemsPool: IPool
    {
        private ObjectPool<IPoolable> _pool;
        private IPoolable _poolable;
        
        public ItemsPool(IPoolable poolable, int defaultCapacity = 10, int maxSize = 1000)
        {
            _poolable = poolable;
            _pool = new ObjectPool<IPoolable>(OnCreateFromPool, OnGetFromPool, OnReleaseFromPool, OnDestroyFromPool, true, defaultCapacity, maxSize);
        }

        public IPoolable TakeFromPool(Vector3 position, Quaternion rotation, Transform parent)
        {
            var item = TakeFromPool();
            item.SetTransformProperties(position, rotation, parent);
            return item;
        }
        
        public IPoolable TakeFromPool()
        {
            return _pool.Get();
        }
        
        public void ReturnToPool(IPoolable poolable)
        {
            _pool.Release(poolable);
        }

        private IPoolable OnCreateFromPool()
        {
            var newPoolable = _poolable.CreateNewInstance();
            newPoolable.InitializeByPool(this);
            return newPoolable;
        }
        
        private void OnDestroyFromPool(IPoolable obj)
        {
            obj.OnDestroyFromPool();
        }

        private void OnReleaseFromPool(IPoolable obj)
        {
            obj.OnReleaseFromPool();
        }

        private void OnGetFromPool(IPoolable obj)
        {
            obj.OnTakeFromPool();
        }
    }
}
