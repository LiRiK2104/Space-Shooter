using System;
using System.Collections;
using Helpers;
using Helpers.Screen;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Services.PoolService
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] 
        private SpawnableObject template;

        [SerializeField, MinMaxSlider(0.1f, 10)] 
        private Vector2 spawnIntervalRange;
        
        [SerializeField, Range(1, 10)] 
        private int spawnPointsCount = 3;
        
        [SerializeField, Range(1, 5)] 
        private float distanceFromScreen = 1;

        [SerializeField] 
        private Color gizmosColor = Color.red;

        private Pool _pool;
        

        [Inject]
        private void Construct(Pool pool)
        {
            _pool = pool;
        }

        private void OnDrawGizmos()
        {
            float sphereRadius = 0.5f;
            Vector2[] spawnPoints = GetSpawnPoints();

            Gizmos.color = gizmosColor;
        
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Gizmos.DrawSphere(spawnPoints[i], sphereRadius);
            }
        }

        
        public void StartSpawn(int leftSpawnsCount)
        {
            StartCoroutine(Spawn(leftSpawnsCount));
        }

        private Vector2[] GetSpawnPoints()
        {
            ScreenWorldSpaceData screenWorldSpaceData = ScreenCalculator.GetScreenWorldSpaceData();
            int gapsCount = spawnPointsCount + 1;
            float gapDistance = screenWorldSpaceData.Size.x / gapsCount;

            Vector2[] spawnPoints = new Vector2[spawnPointsCount];
            float y = screenWorldSpaceData.Max.y + distanceFromScreen;

            spawnPoints[0] = new Vector2(screenWorldSpaceData.Min.x + gapDistance, y);
        
            for (int i = 1; i < spawnPointsCount; i++)
            {
                spawnPoints[i] = new Vector2(spawnPoints[i - 1].x + gapDistance, y);
            }

            return spawnPoints;
        }

        private IEnumerator Spawn(int leftSpawnsCount)
        {
            while (leftSpawnsCount > 0)
            {
                float interval = Random.Range(spawnIntervalRange.x, spawnIntervalRange.y);

                yield return new WaitForSeconds(interval);
                
                Vector2[] spawnPoints = GetSpawnPoints();
                Vector2 spawnPoint = Utils.GetRandomElement(spawnPoints);
                Vector3 eulerRotation = new (0, 0, 180);
                Quaternion startRotation = Quaternion.Euler(eulerRotation);

                _pool.Spawn(template, spawnPoint, startRotation);
                
                leftSpawnsCount--;
            }
        }
    }
}
