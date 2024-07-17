using UnityEngine;

namespace Meta.Player
{
    [RequireComponent(typeof(ScreenZone))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10)] private float speed;

        private ScreenZone _movementZone;
        private Renderer _renderer;

    
        private void Awake()
        {
            _movementZone = GetComponent<ScreenZone>();
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector2 direction = new (x, y);
            Move(direction);
        }


        private void Move(Vector2 direction)
        {
            Vector3 offset = direction * (Time.deltaTime * speed);

            transform.position = _movementZone.GetClampedPosition(
                transform.position + offset, _renderer.bounds.size);
        }
    }
}
