using System;
using System.Collections.Generic;
using Core.Services.PoolService;
using Meta.Shooting;
using UnityEngine;
using Zenject;

namespace Core.Services.Progress
{
    public class EnemiesKillsProgress : MonoBehaviour, IPercentable
    {
        private EnemiesSpawner _enemiesSpawner;
        
        private List<IDamagable> _observerables = new();
    
        private int _killedEnemies;
    
        public event Action Changed;

        public float Percent => _killedEnemies / (float)_enemiesSpawner.TargetEnemiesCount;


        [Inject]
        private void Construct(EnemiesSpawner enemiesSpawner)
        {
            _enemiesSpawner = enemiesSpawner;
        }

        private void OnEnable()
        {
            _enemiesSpawner.Spawned += AddObserverable;
        }

        private void OnDisable()
        {
            if (_enemiesSpawner != null)
            {
                _enemiesSpawner.Spawned -= AddObserverable;   
            }
        }

        private void Start()
        {
            Changed?.Invoke();
        }

        private void OnDestroy()
        {
            _observerables.ForEach(observerable => observerable.Died -= AddPoint);
        }
        
    
        private void AddObserverable(SpawnableObject spawnableObject, bool isCreated)
        {
            if (isCreated && spawnableObject.TryGetComponent(out IDamagable damagable))
            {
                _observerables.Add(damagable);

                damagable.Died += AddPoint;
            }
        }

        private void AddPoint()
        {
            _killedEnemies++;
            
            Changed?.Invoke();
        }
    }
}
