using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 pos = transform.position;
            transform.position = Vector3.MoveTowards(pos, target.position, 0.1f * speed);

            Vector3 diff = target.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
