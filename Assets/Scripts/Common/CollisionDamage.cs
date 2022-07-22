using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public string enemyTag;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            Health health = collision.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
