using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Storey : MonoBehaviour
{
    [SerializeField] GameObject endPosition;
    [SerializeField] float time;
    private bool onStairs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onStairs = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onStairs = false;
        }
    }

    private void Update()
    {
        if (onStairs)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                GameObject.Find("Player").GetComponent<Animator>().Play("Enter");
                StartCoroutine(AnimDelay());
            }
        }
    }

    private IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("Player").transform.position = endPosition.transform.position;

        if (GameObject.Find("Player").GetComponent<Player_Movement>().hasGift)
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Out_gift");
        }
        else
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Out_nogift");
        }

        yield return new WaitForSeconds(time);

        if (GameObject.Find("Player").GetComponent<Player_Movement>().hasGift)
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Idle_gift");
        }
        else
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Idle_nogift");
        }
    }
}
