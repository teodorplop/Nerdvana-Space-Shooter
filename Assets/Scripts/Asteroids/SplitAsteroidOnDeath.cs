using UnityEngine;

public class SplitAsteroidOnDeath : MonoBehaviour
{
    public GameObject smallerAsteroid;

    Health health;
    
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.CurrentHealth <= 0)
        {
            GameObject asteroid1 = Instantiate(smallerAsteroid, transform.position, Quaternion.identity);
            GameObject asteroid2 = Instantiate(smallerAsteroid, transform.position, Quaternion.identity);

            asteroid1.GetComponent<FollowDirection>().direction = new Vector2(0.5f, -0.5f).normalized;
            asteroid2.GetComponent<FollowDirection>().direction = new Vector2(-0.5f, -0.5f).normalized;
        }
    }
}
