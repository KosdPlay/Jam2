using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B : MonoBehaviour
{
    [SerializeField] private GameObject hint;

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
                Destroy(this.gameObject);
                SceneManager.LoadScene("Menu");
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
