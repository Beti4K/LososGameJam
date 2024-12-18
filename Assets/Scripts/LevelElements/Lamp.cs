using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] bool isBroken;

    void Start()
    {
        GetComponent<Light2D>().enabled = false;

        if (isBroken)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            StartCoroutine(FlashLight());
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBroken && collision.CompareTag("Player") && GetComponent<Light2D>().enabled == false)
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
