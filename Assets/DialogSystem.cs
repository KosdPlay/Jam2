using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    [SerializeField] private TMP_Text ded;

    [SerializeField] private List<GameObject> allStory;

    [SerializeField] private bool a = false;

    private int i;

    private int replica;

    [SerializeField] private List<GameObject> dedsAnnoyedWords;
    [SerializeField] private List<GameObject> unavailable;
    [SerializeField] private List<GameObject> rejection;

    public bool canMove;
    public static DialogSystem instantiate;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator DedAnim;
    [SerializeField] private int playerState;
    [SerializeField] private int DedState;

    private void Start()
    {
        hint.SetActive(false);
        CloseDialog();
        instantiate = this;
        canMove = true;
        ClearPanel();
        a = false;
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
                hint.SetActive(false);
                canMove = false;
                if (!a)
                {
                    allStory[0].SetActive(true);
                }
                else if(a || Story.instantiate.rejection == 2)
                {
                    unavailable[i].SetActive(true);
                }
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
        ClearPanel();
        canMove = true;
        a = true;
    }

    public void RejectionOption()
    {
        Story.instantiate.rejection += 1;
        ClearPanel();

        rejection[0].SetActive(true);
        i = 2;
    }

    public void NextReplica()
    {
        playerAnim.SetInteger("State", playerState);
        DedAnim.SetInteger("State", playerState);
        a = true;
        ClearPanel();
        replica++;

        allStory[replica].SetActive(true);
    }

    private void ClearPanel()
    {
        for (int j = 0; j < allStory.Count; j++)
        {
            allStory[j].SetActive(false);
        }
        for (int j = 0; j < unavailable.Count; j++)
        {
            unavailable[j].SetActive(false);
        }
        for (int j = 0; j < dedsAnnoyedWords.Count; j++)
        {
            dedsAnnoyedWords[j].SetActive(false);
        }
        for (int j = 0; j < rejection.Count; j++)
        {
            rejection[j].SetActive(false);
        }
    }

    public void Next()
    {
        switch (Story.instantiate.cycle)
        {
            case 0:
                Story.instantiate.firstStory = true;
                break;
            case 1:
                Story.instantiate.firstStory = true;
                Story.instantiate.secondStory = true;
                break;
            case 2:
                Story.instantiate.firstStory = true;
                Story.instantiate.secondStory = true;
                Story.instantiate.thirdStory = true;
                break;
            case 3:
                Story.instantiate.firstStory = true;
                Story.instantiate.secondStory = true;
                Story.instantiate.thirdStory = true;
                Story.instantiate.fourthStory = true;
                break;
        }
        NextReplica();
    }

    public void GoodOption()
    {
        Story.instantiate.good += 1;
        i = 0;
        ClearPanel();

        NextReplica();
    }

    public void BadOption()
    {
        Story.instantiate.bad += 1;

        ClearPanel();
        i = 1;
        dedsAnnoyedWords[i].SetActive(false);
    }

}
