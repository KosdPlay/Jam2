using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<GameObject> first;
    [SerializeField] private List<GameObject> second;
    [SerializeField] private List<GameObject> third;


    [SerializeField] private List<GameObject> allStory;

    private int replica;

    public static Dialogue instantiate;

    [SerializeField] private Animator playerAnim;
    private void Awake()
    {
        instantiate = this;
        if (first.Count != 0)
        {
            for (int j = 0; j < first.Count; j++)
            {
                first[j].SetActive(false);
            }
        }
        if (second != null)
        {
            for (int j = 0; j < second.Count; j++)
            {
                second[j].SetActive(false);
            }
        }
        if (third != null)
        {
            for (int j = 0; j < third.Count; j++)
            {
                third[j].SetActive(false);
            }
        }
    }


    public void StartDial(int story)
    {
        switch (story)
        {
            case 1:
                allStory = first;
                break;
            case 2:
                allStory = second;
                break;
            case 3:
                allStory = third;
                break;
            default:
                break;
        }
        allStory[0].SetActive(true);
        DialogSystem.instantiate.canMove = false;
    }

    public void CloseDialog()
    {
        ClearPanel();
        DialogSystem.instantiate.canMove = true;
        allStory.Clear();
        replica = 0;
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
            default:
                break;
        }
        ClearPanel();
        replica++;

        allStory[replica].SetActive(true);
    }

    private void ClearPanel()
    {
        Debug.Log("?");
        for (int j = 0; j < allStory.Count; j++)
        {
            allStory[j].SetActive(false);
        }
    }

}
