using System;
using System.Linq;
using UnityEngine;

namespace Meta.Shooting
{
    public class Radar : MonoBehaviour
    {
        private const float ScaleCoefficient = 1.5f;
        
        [SerializeField] private float radius = 3;
        [SerializeField] private LayerMask layerMask;


        private void OnValidate()
        {
            transform.localScale = Vector3.one * radius / ScaleCoefficient;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        

        public bool TryGetClosest(out Transform closestTarget)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask.value);

            if (colliders.Length == 0)
            {
                closestTarget = null;
                return false;
            }
            
            closestTarget = colliders
                .OrderBy(foundCollider => Vector2.Distance(transform.position, foundCollider.transform.position))
                .First()
                .transform;

            return closestTarget != null;
        }
    }
}