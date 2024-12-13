using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chihuahua : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int penalty;
    [SerializeField] float waitTime;

    private bool seesPlayer;
    private bool isAttacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.x - transform.position.x < 0)
            {
                speed *= -1;
            }

            seesPlayer = true;
            StartCoroutine(WaitBeforeAttack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seesPlayer = false;
            waitTime = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("level_timer").GetComponent<Level_Timer>().TimePenalty(penalty);
        }
        else
        {
            speed *= -1;
        }
    }

    void Update()
    {
        if (seesPlayer && isAttacking && GameObject.Find("Player").GetComponent<Player_Movement>().isGameActive == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    private IEnumerator WaitBeforeAttack()
    {
        yield return new WaitForSeconds(waitTime);
        waitTime = 0;
        isAttacking = true;
    }
}
