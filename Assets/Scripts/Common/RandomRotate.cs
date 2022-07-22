using UnityEngine;

/// <summary>
/// Attaching this component to an object will make it rotate with a random speed in a random direction.
/// </summary>
public class RandomRotate : MonoBehaviour
{
    [SerializeField] private float minSpeed = 5;
    [SerializeField] private float maxSpeed = 30;

    private Vector3 rotateAxis = new Vector3(0, 0, 1);
    private float speed;

    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        
        if (Random.Range(0, 2) == 1)
        {
            speed *= -1;
        }
    }

    private void Update()
    {
        transform.Rotate(rotateAxis, speed * Time.deltaTime);
    }
}
