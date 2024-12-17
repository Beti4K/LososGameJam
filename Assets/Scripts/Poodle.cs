using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poodle : MonoBehaviour
{
    private float startSpeed;
    [SerializeField] float newSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startSpeed = collision.gameObject.GetComponent<Player_Movement>().speed;
            collision.gameObject.GetComponent<Player_Movement>().speed = newSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Movement>().speed = startSpeed;
        }
    }
}
