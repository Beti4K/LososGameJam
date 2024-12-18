using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    public int direction = 1;

    [SerializeField] float throwDelay;
    [SerializeField] GameObject[] things;
    [SerializeField] GameObject parent;

    private bool seesPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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

    private void Update()
    {
        if (seesPlayer)
        {
            if (GameObject.Find("Player").transform.position.x - parent.transform.position.x > 0 && direction == -1)
            {
                direction *= -1;
                parent.transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
            }
            else if (GameObject.Find("Player").transform.position.x - parent.transform.position.x < 0 && direction == 1)
            {
                direction *= -1;
                parent.transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private IEnumerator WaitForThrow()
    {
        yield return new WaitForSeconds(throwDelay);

        GetComponent<Animator>().SetBool("isThrowing", true);
        yield return new WaitForSeconds(0.33f);

        if (direction > 0)
        {
            Instantiate(things[Random.Range(0, things.Length)], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(things[Random.Range(0, things.Length)], transform.position, Quaternion.Inverse(Quaternion.identity));
        }

        GetComponent<Animator>().SetBool("isThrowing", false);

        if (seesPlayer)
        {
            StartCoroutine(WaitForThrow());
        }
    }
}
