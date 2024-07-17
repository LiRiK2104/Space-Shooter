using Core.Services.Screen;
using Helpers.Screen;
using UnityEngine;
using Zenject;

namespace Meta
{
    public class ScreenZone : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1)] 
        private float heightPercent;

        [SerializeField] 
        private Color gizmosColor = Color.yellow;
        
        private ScreenWorldSpaceData _screenWorldSpaceData;
        private ScreenResizeDetector _screenResizeDetector;

        private Vector2 Min => new(0, 0);
        private Vector2 Max => new(1, 1 * heightPercent);


        [Inject]
        private void Construct(ScreenResizeDetector screenResizeDetector)
        {
            _screenResizeDetector = screenResizeDetector;
        }
        
        private void Awake()
        {
            UpdateScreenData();
        }

        private void OnEnable()
        {
            _screenResizeDetector.ScreenSizeChanged += UpdateScreenData;
        }

        private void OnDisable()
        {
            _screenResizeDetector.ScreenSizeChanged -= UpdateScreenData;
        }


        private void OnDrawGizmos()
        {
            UpdateScreenData();

            Gizmos.color = gizmosColor;
            Gizmos.DrawWireCube(_screenWorldSpaceData.Center, _screenWorldSpaceData.Size);
        }


        public Vector2 GetClampedPosition(Vector2 playerPosition, Vector2 playerSize)
        {
            Vector2 playerHalfSize = playerSize / 2;

            Vector2 min = _screenWorldSpaceData.Min + playerHalfSize;
            Vector2 max = _screenWorldSpaceData.Max - playerHalfSize;

            float clampedX = Mathf.Clamp(playerPosition.x, min.x, max.x);
            float clampedY = Mathf.Clamp(playerPosition.y, min.y, max.y);

            return new Vector2(clampedX, clampedY);
        }
        
        public Vector2 GetRandomClampedPosition(Vector2 playerSize)
        {
            Vector2 playerHalfSize = playerSize / 2;

            Vector2 min = _screenWorldSpaceData.Min + playerHalfSize;
            Vector2 max = _screenWorldSpaceData.Max - playerHalfSize;

            float clampedX = Random.Range(min.x, max.x);
            float clampedY = Random.Range(min.y, max.y);

            return new Vector2(clampedX, clampedY);
        }

        private void UpdateScreenData()
        {
            _screenWorldSpaceData = ScreenCalculator.GetScreenWorldSpaceData(Min, Max);
        }
    }
}
