using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class CalendarButton : MonoBehaviour
{
    [SerializeField] GameObject[] stars;
    [SerializeField] Sprite[] starSprites; //0 = inactive, 1 = active

    private GameManager gameManager;
    private string levelNumber;

    private void Start()
    {
        gameManager = GameManager.Instance;

        levelNumber = GetComponentInChildren<TextMeshProUGUI>().text;

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<UnityEngine.UI.Image>().sprite = starSprites[0];
        }

        for (int i = 0; i < gameManager.starsInLevels[int.Parse(levelNumber)]; i++)
        {
            stars[i].GetComponent<UnityEngine.UI.Image>().sprite = starSprites[1];
        }

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(levelLoad);
    }

    private void Update()
    {
        if (!GetComponent<UnityEngine.UI.Button>().interactable)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(false);
            }
        }
    }
    public void levelLoad()
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }
}
