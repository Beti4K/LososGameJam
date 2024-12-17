using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Timer : MonoBehaviour
{
    [SerializeField] int levelTime;
    private GameObject player;

    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject clock;

    void Start()
    {
        StartCoroutine(TimePass());
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (levelTime >= 0)
        {
            timer.text = levelTime.ToString();
        }
        else
        {
            timer.text = "0";
        }

        if (levelTime <= 20)
        {
            timer.color = new Color32(155, 32, 30, 255);
        }
        else
        {
            timer.color = Color.black;
        }
    }

    private IEnumerator TimePass()
    {
        yield return new WaitForSeconds(1);
        levelTime -= 1;
        
        if (levelTime <= 0)
        {
            player.GetComponent<Player_Movement>().LevelLose();
        }
        else
        {
            StartCoroutine(TimePass());
        }

        if (levelTime <= 20)
        {
            StartCoroutine(Pulse());
        }
    }

    private IEnumerator Pulse()
    {
        for (int i = 0; i < 2; i++)
        {
            clock.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
            yield return new WaitForSeconds(0.25f);
            clock.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void TimePenalty(int penalty)
    {
        if (levelTime <= penalty)
        {
            player.GetComponent<Player_Movement>().LevelLose();
            levelTime = 0;
        }
        else
        {
            levelTime -= penalty;
            timer.color = Color.red;
            StartCoroutine(RedMoment());
        }
    }

    private IEnumerator RedMoment()
    {
        yield return new WaitForSeconds(0.3f);
        timer.color = Color.black;
    }
}
