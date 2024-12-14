using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poodle : MonoBehaviour
{
    private Level_Stress levelStress;

    [SerializeField] int penalty;

    private void Start()
    {
        levelStress = GameObject.Find("level_timer").GetComponent<Level_Stress>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelStress.JollyPenalty(penalty);
    }
}
