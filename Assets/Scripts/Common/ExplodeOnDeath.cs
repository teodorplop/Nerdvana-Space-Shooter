using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDeath : MonoBehaviour
{
    public ExplosionType explosionType;

    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void LateUpdate()
    {
        if (health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Explosions.DoExplosion(explosionType, transform.position);
        }
    }
}
