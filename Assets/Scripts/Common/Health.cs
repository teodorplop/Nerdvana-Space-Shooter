using UnityEngine;

/// <summary>
/// Very simple health component
/// </summary>
public class Health : MonoBehaviour
{
	public int health;
	int currentHealth;

	public int CurrentHealth => currentHealth;

	private void Awake()
	{
		currentHealth = health;
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		currentHealth = Mathf.Max(currentHealth, 0);
	}
}
