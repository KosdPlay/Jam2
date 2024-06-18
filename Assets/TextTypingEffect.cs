using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTypingEffect : MonoBehaviour
{
    public TMP_Text textComponent; // ������ �� ��������� ������   
    public string fullText; // ������ �����, ������� ����� �������   
    private float typingSpeed = 0.075f; // �������� ������ ������   

    private string currentText = " "; // ������� ���������� �����   
    private bool isTyping = false; // ����, �����������, ���� �� � ������ ������ ����� ������   

    void OnEnable()
    {
        textComponent = GetComponent<TMP_Text>();
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
