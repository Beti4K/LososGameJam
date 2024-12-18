using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chihuahua_Friend : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Awake", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Awake", false);
        }
    }
}
