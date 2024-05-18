using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that will follow a target
/// </summary>
public class FollowTarget : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float speed;

	private void Update()
	{
		if (target == null)
		{
			// If the target is null, we'll also destroy this object
			Destroy(gameObject);
		}
		else
		{
			// Move towards the target
			Vector3 pos = transform.position;
			transform.position = Vector3.MoveTowards(pos, target.position, 0.1f * speed);

			// Rotate towards the target
			Vector3 diff = target.position - transform.position;
			diff.Normalize();
			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		}
	}
}
