using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    private int direction = 1;

    [SerializeField] float throwDelay;
    [SerializeField] GameObject[] things;

    private bool seesPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.x - transform.position.x < 0)
            {
                direction *= -1;
                transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
            }

            seesPlayer = true;
            StartCoroutine(WaitForThrow());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seesPlayer = false;
        }
    }

    private IEnumerator WaitForThrow()
    {
        yield return new WaitForSeconds(throwDelay);
        Instantiate(things[Random.Range(0, things.Length)], transform.position, Quaternion.identity);

        if (seesPlayer)
        {
            StartCoroutine(WaitForThrow());
        }
    }
}
