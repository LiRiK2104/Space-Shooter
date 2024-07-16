using UnityEngine;

namespace Helpers.Screen
{
    public static class ScreenCalculator
    {
        public static ScreenWorldSpaceData GetScreenWorldSpaceData()
        {
            return new ScreenWorldSpaceData();
        }
        
        public static ScreenWorldSpaceData GetScreenWorldSpaceData(Vector2 min, Vector2 max)
        {
            return new ScreenWorldSpaceData(min, max);
        }
    }
}
