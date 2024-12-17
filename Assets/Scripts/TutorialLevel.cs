using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialLevel : MonoBehaviour
{
    [SerializeField] GameObject dialogueWindow;
    [SerializeField] TextMeshProUGUI dialogueWindowText;

    [SerializeField] GameObject[] elements;
    [SerializeField] string[] texts;

    [SerializeField] GameObject next;
    [SerializeField] GameObject finish;

    [SerializeField] GameObject[] afterTutorial;

    private int currentText;

    private void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetActive(false);
        }
        dialogueWindow.SetActive(false);
        currentText = 0;

        for (int i = 0; i < afterTutorial.Length; i++)
        {
            afterTutorial[i].SetActive(false);
        }
    }
    private void Update()
    {
        dialogueWindowText.text = texts[currentText];

        if (currentText == texts.Length-1)
        {
            next.SetActive(false);
            finish.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentText < texts.Length)
        {
            UpdateTutorial();
        }
    }

    public void StartTutorial()
    {
        Time.timeScale = 0;
        dialogueWindow.SetActive(true);
        elements[currentText].SetActive(true);
    }

    public void UpdateTutorial()
    {
        currentText += 1;
        elements[currentText].SetActive(true);
    }

    public void EndTutorial()
    {
        Time.timeScale = 1;
        dialogueWindow.SetActive(false);

        for (int i = 0; i < afterTutorial.Length; i++)
        {
            if (afterTutorial[i].activeSelf)
            {
                afterTutorial[i].SetActive(false);
            }
            else
            {
                 afterTutorial[i].SetActive(true);
            }
               
        }
    }
}
