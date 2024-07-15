using UnityEngine;

public class PlayerMovementZone : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1)] private float heightPercent;

    private Vector2 Min => Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    private Vector2 Max => Camera.main.ViewportToWorldPoint(new Vector2(1, 1 * heightPercent));
    
    private void OnDrawGizmos()
    {
        Vector2 min = Min;
        Vector2 max = Max;
        Vector2 size = new (max.x - min.x, max.y - min.y);
        Vector2 center = new (min.x + size.x / 2, min.y + size.y / 2);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }


    public Vector2 GetClampedPosition(Vector2 playerPosition, Vector2 playerSize)
    {
        Vector2 playerHalfSize = playerSize / 2;
        
        Vector2 min = Min + playerHalfSize;
        Vector2 max = Max - playerHalfSize;

        float clampedX = Mathf.Clamp(playerPosition.x, min.x, max.x);
        float clampedY = Mathf.Clamp(playerPosition.y, min.y, max.y);

        return new Vector2(clampedX, clampedY);
    }
}
