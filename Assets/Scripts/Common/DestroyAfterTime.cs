using UnityEngine;

/// <summary>
/// Component that will destroy an object after some time
/// </summary>
public class DestroyAfterTime : MonoBehaviour
{
	[SerializeField] private float time = 1;

	private void Start()
	{
		Destroy(gameObject, time);
	}
}
