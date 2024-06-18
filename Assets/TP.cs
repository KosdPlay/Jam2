using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject O2;
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
                O2.SetActive(true);
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
