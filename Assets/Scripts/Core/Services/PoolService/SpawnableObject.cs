using System;
using UnityEngine;
using Zenject;

namespace Core.Services.PoolService
{
    public class SpawnableObject : MonoBehaviour
    {
        [SerializeField] private ObjectType type;

        private Pool _pool;
        public ObjectType Type => type;
        
        
        [Inject]
        private void Construct(Pool pool)
        {
            _pool = pool;
        }

        private void OnDisable()
        {
            _pool.Add(this);
        }
    }
}