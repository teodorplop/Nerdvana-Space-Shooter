using UnityEngine;

/// <summary>
/// Implementation of PlayerMovement. Uses Axis to change player position.
/// </summary>
public class PlayerAxisMovement : PlayerMovement
{
    [SerializeField] private float speed = 1;
    
    protected override Vector2 ComputeMovementDelta(float deltaTime)
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement *= speed * deltaTime;
        return movement;
    }
}
