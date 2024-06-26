using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	[SerializeField] private GameObject[] bulletPrefab;
	[SerializeField] private Transform point2;
    [SerializeField] private float speed;
    private bool a = false;

    private void FixedUpdate()
    {
        if (LevelManager.instantiate.game && !a)
        {
            a = true;
            Invoke("SpawnAst", speed);
        }
        if (!LevelManager.instantiate.game && a)
        {
            Destroy(this);
        }
    }


    private void SpawnAst()
    {
        Instantiate(bulletPrefab[Random.Range(0, bulletPrefab.Length)], point2.position + new Vector3(UnityEngine.Random.Range(-9f, 9f), 0, 0), point2.rotation);
        Invoke("SpawnAst", speed);
    }


}
