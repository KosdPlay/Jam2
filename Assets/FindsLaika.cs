using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindsLaika : MonoBehaviour
{
    private bool a = false;
    [SerializeField] private GameObject hint;

    private void Start()
    {
        hint.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!a)
            {
                hint.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    Dialogue.instantiate.StartDial(2);
                    a = true;
                }
            }
            else
            {
                hint.SetActive(false);
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
