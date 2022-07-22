using UnityEngine;

/// <summary>
/// Handles asteroid spawning at the top of the screen.
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float viewportLeftLimit = 0;
    [SerializeField] private float viewportRightRight = 1;
    [SerializeField] private float spawnCooldown = 1;

    public Vector2 minDirection;
    public Vector2 maxDirection;

    private float spawnCooldownRemaining;

    private float leftLimit;
    private float rightLimit;
    
    private void Start()
    {
        Camera camera = Camera.main;
        leftLimit = camera.ViewportToWorldPoint(new Vector2(viewportLeftLimit, 0)).x;
        rightLimit = camera.ViewportToWorldPoint(new Vector2(viewportRightRight, 0)).x;
    }
    
    private void Update()
    {
        spawnCooldownRemaining = Mathf.Max(spawnCooldownRemaining - Time.deltaTime, 0);
        if (spawnCooldownRemaining <= Mathf.Epsilon)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]);
        float x = leftLimit + (rightLimit - leftLimit) * Random.Range(0.0f, 1.0f);
        asteroid.transform.position = new Vector2(x, transform.position.y);

        asteroid.GetComponent<FollowDirection>().direction = GenerateRandomDirection();

        spawnCooldownRemaining = spawnCooldown;
    }

    private Vector2 GenerateRandomDirection()
    {
        Vector2 direction;
        direction.x = Random.Range(minDirection.x, maxDirection.x);
        direction.y = Random.Range(minDirection.y, maxDirection.y);
        return direction.normalized;
    }
}
