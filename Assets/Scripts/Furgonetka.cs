using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furgonetka : MonoBehaviour
{
    private bool isInVan;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInVan = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInVan = false;
    }
    void Update()
    {
        if (isInVan)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().hasGift = true;
            }
        }

        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
