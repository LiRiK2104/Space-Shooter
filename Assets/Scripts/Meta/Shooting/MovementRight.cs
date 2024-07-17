using UnityEngine;

namespace Meta.Shooting
{
    public class MovementRight : MonoBehaviour
    {
        [SerializeField, Min(0)] private float speed;

        private void Update()
        {
            float distance = speed * Time.deltaTime;
            Vector3 translation = Vector3.right * distance;
            
            transform.Translate(translation);
        }
    }
}