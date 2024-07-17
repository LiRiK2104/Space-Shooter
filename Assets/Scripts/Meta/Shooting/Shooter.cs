using System.Collections;
using Core.Services.PoolService;
using UnityEngine;
using Zenject;

namespace Meta.Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1f)] 
        private float shootingInterval = 0.5f;
    
        [SerializeField] 
        private Transform shootPoint;
    
        [SerializeField] 
        private Radar radar;
        
        [SerializeField] 
        private SpawnableObject bulletTemplate;

        private Pool _pool;


        [Inject]
        private void Construct(Pool pool)
        {
            _pool = pool;
        }

        private void Start()
        {
            StartCoroutine(Shoot());
        }


        private IEnumerator Shoot()
        {
            WaitForSeconds waiting = new (shootingInterval);
        
            while (true)
            {
                if (radar.TryGetClosest(out Transform target))
                {
                    Vector3 direction = target.position - shootPoint.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(0, 0, angle);
                
                    _pool.Spawn(bulletTemplate, shootPoint.position, rotation);
                }
            
                yield return waiting;
            }
        }
    }
}
