using UnityEngine;

/// <summary>
/// Component that applies damage on collision
/// </summary>
public class CollisionDamage : MonoBehaviour
{
	/// <summary>
	/// What tag the other object needs to have in order to receive damage
	/// </summary>
	[SerializeField] private string enemyTag;
	
	/// <summary>
	/// The amount of damage received
	/// </summary>
	[SerializeField] private int damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(enemyTag))
		{
			// If the other object is the enemy
			// We get its health component and make it take some damage
			Health health = collision.GetComponent<Health>();
			if (health)
			{
				health.TakeDamage(damage);
			}
		}
	}
}
