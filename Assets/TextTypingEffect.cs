using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTypingEffect : MonoBehaviour
{
    public TMP_Text textComponent; // ������ �� ��������� ������   
    public string fullText; // ������ �����, ������� ����� �������   
    private float typingSpeed = 0.075f; // �������� ������ ������   

    private string currentText; // ������� ���������� �����   
    private bool isTyping = false; // ����, �����������, ���� �� � ������ ������ ����� ������   

    [SerializeField] private SkipTyping skipTyping;
    [SerializeField] private FullText text;

    void OnEnable()
    {
        textComponent = GetComponent<TMP_Text>();
        fullText = text.fullText;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            currentText += c;
            textComponent.text = currentText;
            if (c == ' ')
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        isTyping = false;
        skipTyping.Skip();
    }



    private void OnDisable()
    {
        currentText = " ";
    }


    public void StartTyping()
    {
        if (!isTyping)
        {
            StartCoroutine(TypeText());
            isTyping = true;
        }
    }

    public void StopTyping()
    {
        StopCoroutine(TypeText());
        isTyping = false;
    }
}
