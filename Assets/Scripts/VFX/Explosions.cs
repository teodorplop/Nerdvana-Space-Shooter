using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplosionType { Asteroid, Player };

[Serializable]
public class Explosion
{
    public ExplosionType explosionType;
    public GameObject[] explosionObjects;
}

public class Explosions : MonoBehaviour
{
    static Explosions instance;

    public Explosion[] explosions;

    private void Awake()
    {
        instance = this;
    }

    private Explosion GetExplosion(ExplosionType explosionType)
    {
        return Array.Find(explosions, e => e.explosionType == explosionType);
    }

    public static void DoExplosion(ExplosionType explosionType, Vector3 position)
    {
        Explosion explosion = instance.GetExplosion(explosionType);
        if (explosion != null)
        {
            int rng = UnityEngine.Random.Range(0, explosion.explosionObjects.Length);
            Instantiate(explosion.explosionObjects[rng], position, Quaternion.identity);
        }
    }
}
