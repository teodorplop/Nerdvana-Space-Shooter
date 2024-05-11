using UnityEngine;

/// <summary>
/// Base class, used for player abilities. Can be inherit by any ability.
/// </summary>
public abstract class PlayerAbility : MonoBehaviour
{
    private enum FireMode
    {
        AutoFire,
        OnKeyPress
    };

    [SerializeField] private float cooldown = 1.0f;
    [SerializeField] private FireMode fireMode;
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
        
        cooldownRemaining = cooldown;
        Fire();
    }

    protected abstract void Fire();
}
