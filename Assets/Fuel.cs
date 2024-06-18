using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        hint.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                audioSource.PlayOneShot(clip);
                FuelStorage.instantiate.AddItem(1);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(false);
        }
    }
}
