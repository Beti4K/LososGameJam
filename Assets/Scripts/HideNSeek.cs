using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNSeek : MonoBehaviour
{
    [SerializeField] float hiddenTime;
    [SerializeField] int penalty;
    private bool isLooking;
    void Start()
    {
        StartCoroutine(LookDelay());
        isLooking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLooking)
        {
            GameObject.Find("level_timer").GetComponent<Level_Stress>().JollyPenalty(penalty);
        }
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    private IEnumerator LookDelay()
    {
        yield return new WaitForSeconds(hiddenTime);

        GetComponent<Animator>().SetBool("isLooking", true);
        isLooking = true;

        yield return new WaitForSeconds(0.75f);

        GetComponent<Animator>().SetBool("isLooking", false);
        isLooking = false;

        StartCoroutine(LookDelay());
    }
}
