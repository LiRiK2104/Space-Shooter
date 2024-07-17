using System.Collections;
using UnityEngine;

namespace Meta.Big_Space_Ship
{
    [RequireComponent(typeof(ScreenZone))]
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10)] private float speed;
    
        private ScreenZone _movementZone;
        private Renderer _renderer;
    
        private void Awake()
        {
            _movementZone = GetComponent<ScreenZone>();
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            StartCoroutine(Move());
        }


        private IEnumerator Move()
        {
            const float minDistance = 0.2f;
        
            while (true)
            {
                Vector2 targetPosition = _movementZone.GetRandomClampedPosition(_renderer.bounds.size);
            
                while (Vector2.Distance(transform.position, targetPosition) > minDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
                    
                    yield return null;
                }

                yield return null;
            }
        }
    }
}
