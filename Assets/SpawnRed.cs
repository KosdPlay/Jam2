using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRed : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform point2;
    [SerializeField] private float speed;

    private void Start()
    {
        Invoke("SpawnAst", speed);
    }


    private void SpawnAst()
    {
        Instantiate(bulletPrefab, point2.position, new Quaternion(0f, 0f, 0f, 0f));
        Invoke("SpawnAst", speed);
    }

}
