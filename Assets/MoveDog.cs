using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject part;

    [SerializeField] private Animator animator;

    private void Start()
    {
        hint.SetActive(false);
        cat.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            hint.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                DialogSystem.instantiate.canMove = false;
                audioSource.PlayOneShot(clip);
                animator.Play("down");
                part.SetActive(false);
                Invoke("D", 2);
            }
        }
    }

    private void D()
    {
        Debug.Log("?");
        cat.SetActive(true);
        animator.Play("Idle");
        Destroy(this.gameObject);
        DialogSystem.instantiate.canMove = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            hint.SetActive(false);
        }
    }
}
