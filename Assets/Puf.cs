using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puf : MonoBehaviour
{
    [SerializeField] GameObject a;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(a, transform);
            Debug.Log("1");
        }
    }
}
