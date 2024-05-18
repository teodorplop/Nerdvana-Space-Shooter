using UnityEngine;

/// <summary>
/// Base class, used for player abilities. Can be inherit by any ability.
/// </summary>
public abstract class PlayerAbility : MonoBehaviour
{
	/// <summary>
	/// Description of fire modes
	/// </summary>
	private enum FireMode
	{
		AutoFire,
		OnKeyPress
	};

	[SerializeField] private float cooldown = 1.0f;
	[SerializeField] private FireMode fireMode;
	
	/// <summary>
	/// Key that needs to be pressed in case fireMode is OnKeyPress. <br/>
	/// Key can be edited in Edit -> Project Settings -> Input Manager
	/// </summary>
	[SerializeField] private string key;

	private float cooldownRemaining;

	private void Update()
	{
		cooldownRemaining = Mathf.Max(cooldownRemaining - Time.deltaTime, 0);
		if (cooldownRemaining <= Mathf.Epsilon)
		{
			if (fireMode == FireMode.AutoFire || Input.GetButton(key))
			{
				Fire_Internal();
			}
		}
	}

	private void Fire_Internal()
	{
		Debug.Log($"Firing ability: {GetType()}");
		
		// Reset the cooldown, and fire!
		// Fire implementation can be different (it can be a weapon, or an ability)
		cooldownRemaining = cooldown;
		Fire();
	}

	/// <summary>
	/// Classes that inherit this one should implement Fire
	/// </summary>
	protected abstract void Fire();
}
