using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
    [SerializeField] float time;

    private bool onElevator;
    private bool isMoving;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onElevator = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onElevator = false;
        }
    }
    private void Update()
    {
        if (onElevator)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                player.GetComponent<Player_Movement>().isGameActive = false;
                StartCoroutine(WaitForElevator());
            }
        }

        if (isMoving)
        {
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPosition, time * Time.deltaTime);
        }
        else
        {
            player.GetComponent<Collider2D>().enabled = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private IEnumerator WaitForElevator()
    {
        player.GetComponent<Animator>().Play("Enter");

        yield return new WaitForSeconds(0.3f);

        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        isMoving = true;

        yield return new WaitForSeconds(time);
        isMoving = false;

        player.GetComponent<Player_Movement>().isGameActive = true;
        player.GetComponent<SpriteRenderer>().enabled = true;

        if (player.GetComponent<Player_Movement>().hasGift)
        {
            player.GetComponent<Animator>().Play("Out_gift");
        }
        else
        {
            player.GetComponent<Animator>().Play("Out_nogift");
        }

        yield return new WaitForSeconds(0.3f);

        if (player.GetComponent<Player_Movement>().hasGift)
        {
            player.GetComponent<Animator>().Play("Idle_gift");
        }
        else
        {
            player.GetComponent<Animator>().Play("Idle_nogift");
        }
    }
}
