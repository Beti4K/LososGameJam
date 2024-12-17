using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] bool isRotated;
    [SerializeField] int speed;
    private void Start()
    {
        startPosition = transform.localPosition;
    }
    void Update()
    {
        if (isRotated)
        {
            transform.localPosition = new Vector3(startPosition.x + Mathf.PingPong(Time.time / speed, 0.1f), startPosition.y, startPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(startPosition.x, startPosition.y + Mathf.PingPong(Time.time / speed, 0.1f), startPosition.z);
        }
    }
}
