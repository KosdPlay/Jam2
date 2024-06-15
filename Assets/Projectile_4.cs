using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile_4 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Скорость полёта снаряда
    [SerializeField] private float lifetime = 2f; // Время жизни снаряда
    [SerializeField] private int damage = 10; // Урон, который снаряд наносит
    [SerializeField] private string Name = "Player";

    [SerializeField] private GameObject D;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Name))
        {
            Boom();
        }
    }

    public void Boom()
    {
        Instantiate(D, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }

}

