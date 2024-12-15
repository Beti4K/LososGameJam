using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.localPosition;
    }
    void Update()
    {
        transform.localPosition = new Vector3 (startPosition.x, startPosition.y + Mathf.PingPong(Time.time/4, 0.1f), startPosition.z);
    }
}
