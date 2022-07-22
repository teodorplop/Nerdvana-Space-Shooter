using UnityEngine;

/// <summary>
/// A weapon can be considered an ability. This is a very simple weapon, that spawns a single projectile.
/// </summary>
public class PlayerWeapon : PlayerAbility
{
    [SerializeField] private Projectile projectilePrefab;
    
    protected override void Fire()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
    }
}
