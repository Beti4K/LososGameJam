using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNSeek : MonoBehaviour
{
    [SerializeField] float hiddenTime;
    [SerializeField] int penalty;
    private bool isLooking;
    private bool isImmune;
    void Start()
    {
        StartCoroutine(LookDelay());
        isLooking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLooking && !isImmune)
        {
            StartCoroutine(ZoneDmgStop());
            GameObject.Find("level_timer").GetComponent<Level_Stress>().JollyPenalty(penalty);
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

    private IEnumerator ZoneDmgStop()
    {
        isImmune = true;

        yield return new WaitForSeconds(5);

        isImmune = false;
    }
}
