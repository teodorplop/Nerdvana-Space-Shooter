using UnityEngine;

/// <summary>
/// A weapon can be considered an ability. This is a very simple weapon, that spawns a single projectile.
/// </summary>
public class PlayerUltimate : PlayerAbility
{
    [SerializeField] private Projectile projectilePrefab;
    
    protected override void Fire()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Projectile projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;

            FollowTarget follow = projectile.GetComponent<FollowTarget>();
            follow.target = enemy.transform;
        }
    }
}
