using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secret : MonoBehaviour
{
    [SerializeField] int attempts = 0;
    [SerializeField] int attemptsNeeded = 5;

    private bool onElevator;
    void Update()
    {
        if (attemptsNeeded == attempts)
        {
            GetComponent<Elevator>().endPosition = new Vector3 (6.94f, -13.72f, 0);
            GetComponent<Elevator>().time = 4;
        }

        if (onElevator)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                attempts += 1;
            }
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
}
