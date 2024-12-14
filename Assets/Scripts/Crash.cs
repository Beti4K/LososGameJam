using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] int penalty;
    [SerializeField] int force;
    [SerializeField] int degrees;

    private Level_Stress levelStress;
    private int direction;
    private void Start()
    {
        direction = GameObject.Find("grandma_kid").GetComponent<Grandma>().direction;

        GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction, 0) * force, ForceMode2D.Impulse);
        levelStress = GameObject.Find("level_timer").GetComponent<Level_Stress>();
    }
    private void Update()
    {
        transform.Rotate(0, 0, degrees * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelStress.JollyPenalty(penalty);
        }
        Destroy(this.gameObject);
    }
}
