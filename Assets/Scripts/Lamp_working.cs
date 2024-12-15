using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp_working : MonoBehaviour
{
    void Start()
    {
        GetComponent<Light2D>().enabled = false;
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            GetComponent<Light2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponent<Light2D>().enabled == false)
        {
            StartCoroutine(LightsOff());
        }
    }

    private IEnumerator LightsOff()
    {
        GetComponent<Light2D>().enabled = true;

        yield return new WaitForSeconds(5);

        GetComponent<Light2D>().enabled = false;
    }
}
