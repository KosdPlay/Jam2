using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), speed * Time.deltaTime);
    }
}
