using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile_1 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Скорость полёта снаряда
    [SerializeField] private float lifetime = 2f; // Время жизни снаряда
    [SerializeField] private int damage = 10; // Урон, который снаряд наносит
    [SerializeField] private string Name = "Enemy";

    [SerializeField] private GameObject D;


    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
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
            collision.gameObject.GetComponent<Projectile>().Boom();
            Boom();
        }
        else if(collision.CompareTag("T"))
        {
            collision.gameObject.GetComponent<MoveHelicopter>().TakeDamage(damage);
            Boom();
        }
        else if (collision.CompareTag("Boom"))
        {
            collision.gameObject.GetComponent<Projectile_4>().Boom();
            Boom();
        }
    }

    public void Boom()
    {
        Instantiate(D, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }
}
