using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] int penalty;
    private Level_Timer levelTimer;
    private void Start()
    {
        levelTimer = GameObject.Find("level_timer").GetComponent<Level_Timer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        levelTimer.TimePenalty(penalty);
        Destroy(this.gameObject);
    }
}
