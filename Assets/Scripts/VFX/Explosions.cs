using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplosionType { Asteroid, Player };

[Serializable]
public class Explosion
{
	/// <summary>
	/// Enum type of explosion.
	/// </summary>
	public ExplosionType explosionType;
	
	/// <summary>
	/// Objects that should be spawned when this explosion happens
	/// </summary>
	public GameObject[] explosionObjects;
}

public class Explosions : MonoBehaviour
{
	/// <summary>
	/// Static instance of this component
	/// </summary>
	static Explosions instance;

	public Explosion[] explosions;

	/// <summary>
	/// In awake, we retain the instance
	/// </summary>
	private void Awake()
	{
		instance = this;
	}

	private Explosion GetExplosion(ExplosionType explosionType)
	{
		return Array.Find(explosions, e => e.explosionType == explosionType);
	}

	/// <summary>
	/// Static method, can be called from anywhere.
	/// </summary>
	public static void DoExplosion(ExplosionType explosionType, Vector3 position)
	{
		// We get the explosion type from the instance
		Explosion explosion = instance.GetExplosion(explosionType);
		if (explosion != null)
		{
			// If there is an explosion, we instantiate it
			int rng = UnityEngine.Random.Range(0, explosion.explosionObjects.Length);
			Instantiate(explosion.explosionObjects[rng], position, Quaternion.identity);
		}
	}
}
