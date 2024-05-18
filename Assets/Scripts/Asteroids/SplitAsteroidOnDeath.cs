using UnityEngine;

/// <summary>
/// Component that spawns two other objects when the health reaches 0.
/// </summary>
public class SplitAsteroidOnDeath : MonoBehaviour
{
	/// <summary>
	/// Reference to the object to spawn
	/// </summary>
	[SerializeField] private GameObject smallerAsteroid;

	/// <summary>
	/// Reference to the health component
	/// </summary>
	Health health;
	
	private void Awake()
	{
		health = GetComponent<Health>();
	}

	private void Update()
	{
		if (health.CurrentHealth <= 0)
		{
			// If health is below 0, spawn two asteroids
			GameObject asteroid1 = Instantiate(smallerAsteroid, transform.position, Quaternion.identity);
			GameObject asteroid2 = Instantiate(smallerAsteroid, transform.position, Quaternion.identity);

			// And give them some directions
			asteroid1.GetComponent<FollowDirection>().direction = new Vector2(0.5f, -0.5f).normalized;
			asteroid2.GetComponent<FollowDirection>().direction = new Vector2(-0.5f, -0.5f).normalized;
		}
	}
}
