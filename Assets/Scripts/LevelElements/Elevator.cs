using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] GameObject referencePosition;
    public Vector3 endPosition;
    public float time;
    private float delay = 0.3f;

    private bool onElevator;
    private bool isMoving;

    private GameObject player;
    [SerializeField] GameObject brokenSign;
    [SerializeField] bool isBroken;

    private void Start()
    {
        player = GameObject.Find("Player");

        endPosition = new Vector3(0, 1, 0);

        if (isBroken)
        {
            endPosition += transform.position;
            brokenSign.SetActive(true);
            time = 1;
        }
        else
        {
            endPosition += referencePosition.transform.position;
        }
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
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPosition, time * Time.deltaTime);
        }
    }

    private IEnumerator WaitForElevator()
    {
        player.GetComponent<Animator>().Play("Enter");

        yield return new WaitForSeconds(delay);

        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        isMoving = true;

        yield return new WaitForSeconds(time);
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
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

        yield return new WaitForSeconds(delay);

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
