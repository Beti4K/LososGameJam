using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool onDoor;
    [SerializeField] Sprite[] sprites;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onDoor = false;
    }

    void Update()
    {
        if (onDoor)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().hasGift = false;
            }
        }
    }
}
