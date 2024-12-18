using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Stress : MonoBehaviour
{
    [SerializeField] GameObject meterFill;
    [SerializeField] GameObject meter;
    [SerializeField] float jollyAmount = 100;

    private bool isImmune;
   
    void Update()
    {
        meterFill.GetComponent<RectTransform>().localScale = new Vector3(1, (jollyAmount/100), 1);

        if (jollyAmount <= 0)
        {
            GameObject.Find("Player").GetComponent<Player_Movement>().LevelLose();
        }

        if (jollyAmount < 50 && jollyAmount > 20)
        {
            meterFill.GetComponent<UnityEngine.UI.Image>().color = new Color32(221, 162, 85, 255);
        }
        else if (jollyAmount <= 20)
        {
            meterFill.GetComponent<UnityEngine.UI.Image>().color = new Color32(155, 32, 30, 255);
        }
        else
        {
            meterFill.GetComponent<UnityEngine.UI.Image>().color = new Color32(72, 115, 86, 255);
        }
    }

    public void JollyPenalty(int amount)
    {
        if (!isImmune)
        {
            if (amount > 0)
            {
                StartCoroutine(Shake());
                StartCoroutine(DmgStop());
            }
            else
            {
                StartCoroutine(Jump());
            }

            jollyAmount -= amount;

            if (jollyAmount > 100)
            {
                jollyAmount = 100;
            }

            if (jollyAmount < 0)
            {
                jollyAmount = 0;
            }
        }
    }

    private IEnumerator Shake()
    {
        meter.GetComponent<RectTransform>().position += new Vector3(3, 0, 0);
        yield return new WaitForSeconds(0.1f);
        meter.GetComponent<RectTransform>().position -= new Vector3(6, 0, 0);
        yield return new WaitForSeconds(0.1f);
        meter.GetComponent<RectTransform>().position += new Vector3(3, 0, 0);
    }

    private IEnumerator Jump()
    {
        meter.GetComponent<RectTransform>().position += new Vector3(0, 3, 0);
        yield return new WaitForSeconds(0.1f);
        meter.GetComponent<RectTransform>().position -= new Vector3(0, 6, 0);
        yield return new WaitForSeconds(0.1f);
        meter.GetComponent<RectTransform>().position += new Vector3(0, 3, 0);
    }
    private IEnumerator DmgStop()
    {
        isImmune = true;

        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color32(255, 144, 139, 255);
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color32(255, 144, 139, 255);
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color32(255, 144, 139, 255); 
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;

        isImmune = false;
    }
}
