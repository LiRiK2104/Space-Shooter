using UnityEngine;

namespace Meta.Background
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float speed = 0.1f;
    
        private Material _material;
        private float _distance;
        
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");


        private void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            _distance += Time.deltaTime * speed;
            _material.SetTextureOffset(MainTex, Vector2.up * _distance);
        }
    }
}
