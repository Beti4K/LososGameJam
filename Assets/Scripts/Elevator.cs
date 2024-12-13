using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
    [SerializeField] float time;

    private bool onElevator;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().isGameActive = false;
                GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(WaitForElevator());
            }
        }
    }

    private IEnumerator WaitForElevator()
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("Player").transform.position = endPosition;
        GameObject.Find("Player").GetComponent<Player_Movement>().isGameActive = true;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
    }
}
