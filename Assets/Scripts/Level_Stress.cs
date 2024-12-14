using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Stress : MonoBehaviour
{
    [SerializeField] GameObject meterFill;
    [SerializeField] float jollyAmount = 100;
   
    void Update()
    {
        meterFill.GetComponent<RectTransform>().localScale = new Vector3(1, (jollyAmount/100), 1);

        if (jollyAmount == 0)
        {
            GameObject.Find("Player").GetComponent<Player_Movement>().LevelLose();
        }
    }

    public void JollyPenalty(int amount)
    {
        jollyAmount -= amount;

        if (jollyAmount > 100)
        {
            jollyAmount = 100;
        }
    }
}
