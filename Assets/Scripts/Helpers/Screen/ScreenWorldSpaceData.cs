using UnityEngine;

namespace Helpers.Screen
{
    public class ScreenWorldSpaceData
    {
        public readonly Vector2 Min;
        public readonly Vector2 Max;
        public readonly Vector2 Size;
        public readonly Vector2 Center;

        
        public ScreenWorldSpaceData() : this(Vector2.zero, Vector2.one) { }

        public ScreenWorldSpaceData(Vector2 viewportMin, Vector2 viewportMax)
        {
            Camera camera = Camera.main;
            
            if (camera != null)
            {
                Min = camera.ViewportToWorldPoint(viewportMin); 
                Max = camera.ViewportToWorldPoint(viewportMax);
                
                Size = new Vector2(Max.x - Min.x, Max.y - Min.y);
                Center = new Vector2(Min.x + Size.x / 2, Min.y + Size.y / 2);
            }
            else
            {
                Min = default;
                Max = default;
                Size = default;
                Center = default;
            }
        }
    }
}
