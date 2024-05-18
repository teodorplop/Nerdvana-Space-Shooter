using UnityEngine;

/// <summary>
/// Handles asteroid spawning at the exact height this object is placed on.
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
	/// <summary>
	/// Array of prefabs of asteroids
	/// </summary>
	[SerializeField] private GameObject[] asteroidPrefabs;

	[Header("Spawn Settings")]
	/// <summary>
	/// Left limit of viewport to spawn asteroids
	/// </summary>
	[SerializeField] private float viewportLeftLimit = 0;
	/// <summary>
	/// Right limit of viewport to spawn asteroids
	/// </summary>
	[SerializeField] private float viewportRightRight = 1;
	/// <summary>
	/// Cooldown between spawn time of asteroids
	/// </summary>
	[SerializeField] private float spawnCooldown = 1;

	/// <summary>
	/// The asteroids will spawn with a random direction. This is the min direction value.
	/// </summary>
	[SerializeField] private Vector2 minDirection;
	/// <summary>
	/// The asteroids will spawn with a random direction. This is the max direction value.
	/// </summary>
	[SerializeField] private Vector2 maxDirection;

	/// <summary>
	/// Cooldown timer
	/// </summary>
	private float spawnCooldownRemaining;

	/// <summary>
	/// Left limit, in world space
	/// </summary>
	private float leftLimit;
	
	/// <summary>
	/// Right limit, in world space
	/// </summary>
	private float rightLimit;
	
	private void Start()
	{
		Camera camera = Camera.main;
		leftLimit = camera.ViewportToWorldPoint(new Vector2(viewportLeftLimit, 0)).x;
		rightLimit = camera.ViewportToWorldPoint(new Vector2(viewportRightRight, 0)).x;
	}
	
	private void Update()
	{
		// Update cooldown
		spawnCooldownRemaining = Mathf.Max(spawnCooldownRemaining - Time.deltaTime, 0);
		if (spawnCooldownRemaining <= Mathf.Epsilon)
		{
			// If cooldown is ready, let's spawn!
			SpawnAsteroid();
		}
	}
	
	/// <summary>
	/// Spawns a random asteroid
	/// </summary>
	private void SpawnAsteroid()
	{
		// Instantiate a random asteroid
		GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]);
		// Give it a random position
		float x = leftLimit + (rightLimit - leftLimit) * Random.Range(0.0f, 1.0f);
		asteroid.transform.position = new Vector2(x, transform.position.y);

		// And a random direction
		asteroid.GetComponent<FollowDirection>().direction = GenerateRandomDirection();

		// Reset cooldown
		spawnCooldownRemaining = spawnCooldown;
	}

	/// <summary>
	/// Generate a random direction between minDirection and maxDirection
	/// </summary>
	private Vector2 GenerateRandomDirection()
	{
		Vector2 direction;
		direction.x = Random.Range(minDirection.x, maxDirection.x);
		direction.y = Random.Range(minDirection.y, maxDirection.y);
		return direction.normalized;
	}
}
