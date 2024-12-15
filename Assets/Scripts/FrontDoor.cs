using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    private bool atDoor;
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

    void Update()
    {
        if (atDoor && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().isOutside = false;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().isOutside = true;
            }

            GameObject.Find("Player").transform.position = movePlayer;
        }
    }
}
