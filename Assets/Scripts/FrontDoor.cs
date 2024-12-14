using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    private bool atDoor;
    [SerializeField] Vector3 movePlayer; 

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
        if (atDoor)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
                {
                    GameObject.Find("Player").GetComponent<Player_Movement>().isOutside = true;
                }
                else
                {
                    GameObject.Find("Player").GetComponent<Player_Movement>().isOutside = false;
                }
                GameObject.Find("Player").transform.position = movePlayer;
            }
        }
    }
}
