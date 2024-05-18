using UnityEngine;

/// <summary>
/// Add this component to an object so that it will move in a given direction with a given speed.
/// </summary>
public class FollowDirection : MonoBehaviour
{
	[SerializeField] private Vector2 direction = Vector2.up;
	[SerializeField] private float speed = 1;
	
	private void Update()
	{
		// We move each frame in that direction
		Vector2 position2D = transform.position;
		position2D += direction * speed * Time.deltaTime;
		transform.position = position2D;
	}
}
