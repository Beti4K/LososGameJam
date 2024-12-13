using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Storey : MonoBehaviour
{
    [SerializeField] Vector3 endPosition;
    private bool onStairs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onStairs = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onStairs = false;
        }
    }

    private void Update()
    {
        if (onStairs)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject.Find("Player").transform.position = endPosition;
            }
        }
    }
}
