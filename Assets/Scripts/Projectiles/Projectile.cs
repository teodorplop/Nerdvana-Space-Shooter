using UnityEngine;

/// <summary>
/// Very basic Projectile object. When it hits an enemy, it destroys it. 
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
            else
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
