using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] int penalty;
    [SerializeField] int force;

    private Level_Timer levelTimer;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (1, 0) * force, ForceMode2D.Impulse);
        levelTimer = GameObject.Find("level_timer").GetComponent<Level_Timer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelTimer.TimePenalty(penalty);
        }
        Destroy(this.gameObject);
    }
}
