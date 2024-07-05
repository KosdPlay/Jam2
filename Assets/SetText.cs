using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    public TMP_Text textComponent;
    [SerializeField] private FullText text;
    public int state = 0;
    public bool space = false;
    [SerializeField] bool a = false;
    private void OnEnable()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = text.fullText;
    }

    private void Update()
    {
        if (space)
        {
            if(Input.GetKeyDown(KeyCode.Space) && !a)
            {
                LevelManager.instantiate.start();
                Dialogue.instantiate.CloseDialog();
                a = true;
            }
        }
        else if (!text.story)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !a)
            {
                if (state == -1)
                {
                    Dialogue.instantiate.CloseDialog();
                }
                else
                {
                    a = true;
                    Dialogue.instantiate.NextReplica(state);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !a)
            {
                if (state == -1)
                {
                    DialogSystem.instantiate.CloseDialog();
                }
                else
                {
                    a = true;
                    DialogSystem.instantiate.NextReplica(state);
                }
            }
        }

        
    }
}
