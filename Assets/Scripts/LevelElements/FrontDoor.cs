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
        if (atDoor && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            StartCoroutine(Enter());
        }
    }

    private IEnumerator Enter()
    {
        if (isOut)
        {
            player.GetComponent<Animator>().Play("Enter");
        }
        else
        {

            if (player.GetComponent<Player_Movement>().hasGift)
            {
                player.GetComponent<Animator>().Play("Out_gift");
            }
            else
            {
                player.GetComponent<Animator>().Play("Out_nogift");
            }
        }

        yield return new WaitForSeconds(0.3f);

        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;

        player.GetComponent<Player_Movement>().isOutside = !isOut;

        player.transform.position = movePlayer;

        player.GetComponent<Player_Movement>().isGameActive = true;
        player.GetComponent<SpriteRenderer>().enabled = true;

        if (isOut)
        {

            if (player.GetComponent<Player_Movement>().hasGift)
            {
                player.GetComponent<Animator>().Play("Out_gift");
            }
            else
            {
                player.GetComponent<Animator>().Play("Out_nogift");
            }
        }
        else
        {
            player.GetComponent<Animator>().Play("Enter");
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
