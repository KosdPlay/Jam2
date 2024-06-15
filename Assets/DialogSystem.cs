using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject dialogDed;
    [SerializeField] private GameObject dialogPlayer;

    [SerializeField] private string[] dedsWords;
    [SerializeField] private string[] playersWords;

    public bool canMove;
    public static DialogSystem instantiate;

    private void Start()
    {
        hint.SetActive(false);
        CloseDialog();
        instantiate = this;
        canMove = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && RotationPlanet.instantiate.facingRight)
        {
            if (canMove)
            {
                hint.SetActive(true);
            }
            else
            {
                hint.SetActive(false);
            }
            if (Input.GetKey(KeyCode.E))
            {
                dialogDed.SetActive(true);
                dialogPlayer.SetActive(true);
                canMove = false;
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

    public void CloseDialog()
    {
        dialogDed.SetActive(false);
        dialogPlayer.SetActive(false);
        canMove = true;
    }

    public void BadOption()
    {

    }
}
