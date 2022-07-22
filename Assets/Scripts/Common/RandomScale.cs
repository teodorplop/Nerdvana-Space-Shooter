using UnityEngine;

/// <summary>
/// Add this component to an object so that it will multiply its scale with a random value within a given interval.
/// </summary>
public class RandomScale : MonoBehaviour
{
    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float maxScale = 1.0f;

    private void Awake()
    {
        transform.localScale *= Random.Range(minScale, maxScale);
    }
}
