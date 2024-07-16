using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Meta.Enemies
{
    public class MovementForward : MonoBehaviour
    {
        [SerializeField, MinMaxSlider(0.1f, 10f)]
        private Vector2 speedRange;

        private float _speed;

        
        private void Awake()
        {
            _speed = Random.Range(speedRange.x, speedRange.y);
        }

        private void Update()
        {
            Vector3 offset = transform.up * (Time.deltaTime * _speed);

            transform.position += offset;
        }
    }
}
