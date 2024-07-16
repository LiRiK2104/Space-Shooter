using System;
using Core.Services.PoolService;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Services.Progress
{
    [RequireComponent(typeof(Spawner))]
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField, MinMaxSlider(1, 100)] 
        private Vector2 targetEnemiesCountRange;

        private Spawner _spawner;
        private int _killedEnemies = 0;
        
        public int TargetEnemiesCount { get; private set; }


        private void Awake()
        {
            _spawner = GetComponent<Spawner>();
            
            TargetEnemiesCount = Random.Range(
                Mathf.CeilToInt(targetEnemiesCountRange.x), 
                Mathf.CeilToInt(targetEnemiesCountRange.y));
        }

        private void Start()
        {
            _spawner.StartSpawn(TargetEnemiesCount);
        }
    }
}
