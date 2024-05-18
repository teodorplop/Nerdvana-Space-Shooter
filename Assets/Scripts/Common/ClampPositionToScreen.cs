using UnityEngine;

/// <summary>
/// Add this component to an object to clamp his position within the viewport.
/// </summary>
public class ClampPositionToScreen : MonoBehaviour
{
	/// <summary>
	/// Bottom left limit of the view
	/// </summary>
	[SerializeField] private Vector2 viewportBottomLeftLimit = Vector2.zero;
	/// <summary>
	/// Top right limit of the view
	/// </summary>
	[SerializeField] private Vector2 viewportTopRightLimit = Vector2.one;
	
	/// <summary>
	/// Bottom left limit - world space
	/// </summary>
	private Vector2 bottomLeftLimit;
	
	/// <summary>
	/// Top right limit - world space
	/// </summary>
	private Vector2 topRightLimit;
	
	private void Start()
	{
		Camera camera = Camera.main;
		// Transform from view space to world space
		bottomLeftLimit = camera.ViewportToWorldPoint(viewportBottomLeftLimit);
		topRightLimit = camera.ViewportToWorldPoint(viewportTopRightLimit);
	}
	
	/// <summary>
	/// The object will move in update. So after that happens, in LateUpdate, we want to clamp its position.
	/// </summary>
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
