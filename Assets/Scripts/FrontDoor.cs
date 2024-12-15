using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    private GameObject player;
    private bool atDoor;
    private bool isEntering;
    [SerializeField] bool isOut;
    [SerializeField] Vector3 movePlayer;
    [SerializeField] Corridor corridor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atDoor = false;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (atDoor && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            StartCoroutine(Enter());
        }

        if (isEntering)
        {
            player.transform.position = movePlayer;
        }
    }

    private IEnumerator Enter()
    {
        player.GetComponent<Animator>().Play("Enter");

        yield return new WaitForSeconds(0.3f);

        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        isEntering = true;

        player.GetComponent<Player_Movement>().isOutside = !isOut;

        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        isEntering = false;

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
