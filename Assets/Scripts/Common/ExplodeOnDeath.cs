using UnityEngine;

/// <summary>
/// Component that will spawn an explosion when the health is below 0
/// </summary>
public class ExplodeOnDeath : MonoBehaviour
{
	/// <summary>
	/// Type of explosion to spawn
	/// </summary>
	[SerializeField] private ExplosionType explosionType;

	Health health;

	private void Awake()
	{
		health = GetComponent<Health>();
	}

	private void LateUpdate()
	{
		if (health.CurrentHealth <= 0)
		{
			// If health is below 0, we destroy the object and spawn the explosion
			Destroy(gameObject);
			Explosions.DoExplosion(explosionType, transform.position);
		}
	}
}
