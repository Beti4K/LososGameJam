using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField] int reward;
    [SerializeField] Sprite[] sprites;

    private Level_Stress levelStress;

    private void Start()
    {
        levelStress = GameObject.Find("level_timer").GetComponent<Level_Stress>();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelStress.JollyPenalty(reward);
        }
        Destroy(this.gameObject);
    }
}
