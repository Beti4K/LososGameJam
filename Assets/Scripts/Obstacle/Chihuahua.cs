using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chihuahua : MonoBehaviour
{
    [SerializeField] int speedAmount;
    private int speed;
    [SerializeField] int penalty;
    [SerializeField] float waitTime;

    [SerializeField] bool seesPlayer;
    private bool isAttacking;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("wakesUp", true);

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
            isAttacking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("level_timer").GetComponent<Level_Stress>().JollyPenalty(penalty);
        }
    }

    void Update()
    {
        if (seesPlayer)
        {
            if (isAttacking && GameObject.Find("Player").GetComponent<Player_Movement>().isGameActive == true)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                GetComponent<Animator>().SetBool("seesPlayer", true);


                if (GameObject.Find("Player").transform.position.x - transform.position.x > 0)
                {
                    speed = speedAmount;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (GameObject.Find("Player").transform.position.x - transform.position.x < 0)
                {
                    speed = -speedAmount;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        else
        {
            if (transform.localPosition != startPosition)
            {
                GetComponent<Animator>().SetBool("seesPlayer", true);
               
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPosition, speedAmount * Time.deltaTime);

                if (speed < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("seesPlayer", false);
            }
        }    
    }

    private IEnumerator WaitBeforeAttack()
    {
        yield return new WaitForSeconds(waitTime);
        waitTime = 0;
        isAttacking = true;
    }
}
