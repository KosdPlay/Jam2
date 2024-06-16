using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    [SerializeField] private GameObject rocket;

    private void FixedUpdate()
    {
        if (LevelManager.instantiate.game)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rocket.transform.position = Vector2.MoveTowards(transform.position, new Vector3(rocket.transform.position.x + 0.1f, rocket.transform.position.y, rocket.transform.position.z), 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rocket.transform.position = Vector2.MoveTowards(transform.position, new Vector3(rocket.transform.position.x - 0.1f, rocket.transform.position.y, rocket.transform.position.z), 10 * Time.deltaTime);
            }
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rocket.transform.position = Vector2.MoveTowards(transform.position, new Vector3(rocket.transform.position.x, rocket.transform.position.y + 0.1f, rocket.transform.position.z), 10 * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //   rocket.transform.position = Vector2.MoveTowards(transform.position, new Vector3(rocket.transform.position.x, rocket.transform.position.y - 0.1f, rocket.transform.position.z), 10 * Time.deltaTime);
        //}
    }

}