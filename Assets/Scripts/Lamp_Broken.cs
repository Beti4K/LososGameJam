using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp_Broken : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FlashLight());
        GetComponent<Light2D>().enabled = false;
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            GetComponent<Light2D>().enabled = false;
        }
    }

    private IEnumerator FlashLight()
    {
        GetComponent<Light2D>().enabled = false;
        yield return new WaitForSeconds(Random.Range(1,5));

        GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        GetComponent<Light2D>().enabled = false;

        FlashLight();
    }
}
