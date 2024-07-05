using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public bool planet;
    [SerializeField] private GameObject hint;

    [SerializeField] private TMP_Text ded;

    [SerializeField] private List<GameObject> allStory;

    public bool a = false;

    private int i;

    private int replica;

    [SerializeField] private List<GameObject> dedsAnnoyedWords;
    [SerializeField] private List<GameObject> unavailable;
    [SerializeField] private List<GameObject> rejection;

    public bool canMove;
    public static DialogSystem instantiate;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator DedAnim;

    private void Awake()
    {
        instantiate = this;
    }

    private void Start()
    {
        hint.SetActive(false);
        CloseDialog();
        instantiate = this;
        canMove = true;
        ClearPanel();
        a = false;
        DedAnim.SetInteger("State", 0);
        canMove = false;
        if (planet)
        {
            CutsceneManager.Instance.StartCutscene("CS_1");
            Invoke("B", 8);
        }
    }

    private void B() 
    {
        Dialogue.instantiate.StartDial(1);
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
            if (Input.GetKey(KeyCode.E) && canMove == true)
            {
                hint.SetActive(false);
                canMove = false;
                if (!a)
                {
                    switch (Story.instantiate.cycle)
                    {
                        case 0:
                            playerAnim.SetInteger("State", 1);
                            DedAnim.SetInteger("State", 0);
                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:
                            
                            break;
                    }
                    allStory[0].SetActive(true);
                }
                else if(a || Story.instantiate.rejection == 2)
                {
                    unavailable[i].SetActive(true);
                    a = true;
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
        if (i == 2 || i == 1)
        {
            DedAnim.SetInteger("State", 0);
        }
        if(i == 0 && a)
        {
            DedAnim.SetInteger("State", 3);
        }
    }

    public void RejectionOption()
    {

        Story.instantiate.rejection += 1;
        ClearPanel();
        DedAnim.SetInteger("State", 1);
        rejection[0].SetActive(true);
        i = 2;
    }

    public void NextReplica(int w)
    {
        switch (w)
        {
            case 10:
                playerAnim.SetInteger("State", 0);
                break;
            case 11:
                playerAnim.SetInteger("State", 1);
                break;
            case 12:
                playerAnim.SetInteger("State", 2);
                break;
            case 20:
                DedAnim.SetInteger("State", 0);
                break;
            case 21:
                DedAnim.SetInteger("State", 1);
                break;
            case 22:
                DedAnim.SetInteger("State", 2);
                break;
            default:
                break;
        }
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
        NextReplica(0);
    }

    public void GoodOption()
    {
        Story.instantiate.good += 1;
        i = 0;
        ClearPanel();

        NextReplica(0);
    }

    public void BadOption()
    {
        Story.instantiate.bad += 1;

        ClearPanel();
        i = 1;
        dedsAnnoyedWords[0].SetActive(true);
        DedAnim.SetInteger("State", 1);
    }

}
