using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTyping : MonoBehaviour
{
    [SerializeField] private GameObject skipPanel;
    [SerializeField] private GameObject nextPanel;

    private void Start()
    {
        nextPanel.SetActive(false);
        skipPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Skip();
        }
    }

    public void Skip()
    {
        nextPanel.SetActive(true);
        skipPanel.SetActive(false);
    }
}
