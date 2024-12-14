using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Timer : MonoBehaviour
{
    [SerializeField] int levelTime;
    private GameObject player;

    [SerializeField] TextMeshProUGUI timer;

    void Start()
    {
        StartCoroutine(TimePass());
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (levelTime >= 0)
        {
            timer.text = "TIME: " + levelTime;
        }
        else
        {
            timer.text = "TIME: 0";
        }
    }

    private IEnumerator TimePass()
    {
        yield return new WaitForSeconds(1);
        levelTime -= 1;
        
        if (levelTime <= 0)
        {
            player.GetComponent<Player_Movement>().EndOfLevel();
        }
        else
        {
            StartCoroutine(TimePass());
        }
    }

    public void TimePenalty(int penalty)
    {
        if (levelTime <= penalty)
        {
            player.GetComponent<Player_Movement>().EndOfLevel();
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
