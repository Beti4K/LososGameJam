using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry_Down : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
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
                StartCoroutine(AnimDelay());
            }
        }
    }

    private IEnumerator AnimDelay()
    {
        GameObject.Find("Player").GetComponent<Animator>().Play("Enter");

        yield return new WaitForSeconds(0.1f);
        GameObject.Find("Player").transform.position = endPosition;

        if (GameObject.Find("Player").GetComponent<Player_Movement>().hasGift)
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Out_gift");
        }
        else
        {
            GameObject.Find("Player").GetComponent<Animator>().Play("Out_nogift");
        }

        yield return new WaitForSeconds(0.1f);

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
