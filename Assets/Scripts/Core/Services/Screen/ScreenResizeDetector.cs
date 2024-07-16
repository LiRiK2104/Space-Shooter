using System;
using UnityEngine;

namespace Core.Services.Screen
{
    public class ScreenResizeDetector : MonoBehaviour
    {
        private Vector2 _resolution;
        
        public event Action ScreenSizeChanged;
        
        
        private void Awake()
        {
            _resolution = new Vector2(UnityEngine.Screen.width, UnityEngine.Screen.height);
        }
    
        private void Update()
        {
            if (Math.Abs(_resolution.x - UnityEngine.Screen.width) > 0 || 
                Math.Abs(_resolution.y - UnityEngine.Screen.height) > 0)
            {
                _resolution.x = UnityEngine.Screen.width;
                _resolution.y = UnityEngine.Screen.height;
                
                ScreenSizeChanged?.Invoke();
            }
        }
    }
}
