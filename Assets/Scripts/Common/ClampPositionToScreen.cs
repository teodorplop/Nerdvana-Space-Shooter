using UnityEngine;

/// <summary>
/// Add this component to an object to clamp his position within the viewport.
/// </summary>
public class ClampPositionToScreen : MonoBehaviour
{
    [SerializeField] private Vector2 viewportBottomLeftLimit = Vector2.zero;
    [SerializeField] private Vector2 viewportTopRightLimit = Vector2.one;
    
    private Vector2 bottomLeftLimit;
    private Vector2 topRightLimit;
    
    private void Start()
    {
        Camera camera = Camera.main;
        bottomLeftLimit = camera.ViewportToWorldPoint(viewportBottomLeftLimit);
        topRightLimit = camera.ViewportToWorldPoint(viewportTopRightLimit);
    }
    
    private void LateUpdate()
    {
        transform.position = Clamp(transform.position);
    }
    
    private Vector2 Clamp(Vector2 position)
    {
        position.x = Mathf.Clamp(position.x, bottomLeftLimit.x, topRightLimit.x);
        position.y = Mathf.Clamp(position.y, bottomLeftLimit.y, topRightLimit.y);

        return position;
    }
}
