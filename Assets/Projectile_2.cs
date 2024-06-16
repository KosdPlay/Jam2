using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_2 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Скорость полёта снаряда
    [SerializeField] private float lifetime = 2f; // Время жизни снаряда
    [SerializeField] private int damage = 10; // Урон, который снаряд наносит
    [SerializeField] private string Name = "Player";


    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(Name))
        {
            FlightProgress.instantiate.TakeDamage(damage);

        }
        else if (collision.CompareTag("Boom"))
        {
            collision.gameObject.GetComponent<Projectile_4>().Boom();
        }
    }

    private void FixedUpdate()
    {
        if (!LevelManager.instantiate.game)
        {
            Destroy(this.gameObject);
        }
    }
}
