using UnityEngine;

/// <summary>
/// Base class, handles player movement.
/// </summary>
public abstract class PlayerMovement : MonoBehaviour
{
    private void Update()
    {
        Vector2 position2D = transform.position;
        position2D += ComputeMovementDelta(Time.deltaTime);

        transform.position = position2D;
    }

    protected abstract Vector2 ComputeMovementDelta(float deltaTime);
}
