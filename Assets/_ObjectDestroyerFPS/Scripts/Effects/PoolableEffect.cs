using System;
using Arf.Pooling.Interfaces;
using UnityEngine;
using UnityEngine.VFX;

namespace Arf.Pooling.Targets
{
    public class PoolableEffect : MonoBehaviour, IPoolable
    {
        [SerializeField] private ParticleSystem particleSystemVFX;

        private IPool _pool;
        private Transform _transform;

        private void Awake()
        {
            InitializeInternal();
        }

        public void InitializeByPool(IPool pool)
        {
            _pool = pool;
            InitializeInternal();
        }

        public IPoolable CreateNewInstance()
        {
            return Instantiate(this);
        }

        public void SetTransformProperties(Vector3 position, Quaternion rotation, Transform parent)
        {
            _transform.SetParent(parent);
            _transform.SetPositionAndRotation(position, rotation);
        }

        public void OnTakeFromPool()
        {
            gameObject.SetActive(true);
        }
        
        public void OnReleaseFromPool()
        {
            gameObject.SetActive(false);
        }

        public void OnDestroyFromPool()
        {
            Destroy(gameObject);
        }
        
        private void InitializeInternal()
        {
            _transform = transform;
            var particleSystemMain = particleSystemVFX.main;
            particleSystemMain.stopAction = ParticleSystemStopAction.Callback;
        }
        
        private void OnParticleSystemStopped()
        {
            if (_pool == null)
            {
                Destroy(gameObject);
                return;
            }
            _pool.ReturnToPool(this);
        }
    }
}
