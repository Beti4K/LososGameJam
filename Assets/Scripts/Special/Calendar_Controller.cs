using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Calendar_Controller : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] UnityEngine.UI.Button[] levels;
    
    void Start()
    {
        gameManager = GameManager.Instance;

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
        }

        for (int i = 0; i < gameManager.lastLevel; i++)
        {
            levels[i].interactable = true;
        }
    }
}
