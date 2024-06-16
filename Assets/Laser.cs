using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform point2;

    [SerializeField] private float attackCooldown = 0.5f;
    private float lastAttackTime;


    private void Update()
    {
        if (LevelManager.instantiate.game)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))&& Time.time - lastAttackTime >= attackCooldown)
            {
                StartCoroutine(SpawnAst());
            }
        }
    }


    private IEnumerator SpawnAst()
    {
        Instantiate(bulletPrefab, point2.position, point2.rotation);
        yield return new WaitForSeconds(0);
        lastAttackTime = Time.time;

    }
}
