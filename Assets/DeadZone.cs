using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f; // Время жизни снаряда
    [SerializeField] private int damage = 10; // Урон, который снаряд наносит
    [SerializeField] private string Name = "Enemy";


    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Name))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("T"))
        {
            Debug.Log("1");
            collision.gameObject.GetComponent<MoveHelicopter>().TakeDamage(damage);
        }
        if (collision.CompareTag("Player"))
        {
            FlightProgress.instantiate.TakeDamage(damage);
        }
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
