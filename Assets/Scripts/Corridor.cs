using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    [SerializeField] Sprite[] wallpaper;
    [SerializeField] Sprite[] spritesFront;

    [SerializeField] GameObject front;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = wallpaper[Random.Range(0, wallpaper.Length)];
        front.gameObject.GetComponent<SpriteRenderer>().sprite = spritesFront[Random.Range(0, spritesFront.Length)];
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            front.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            front.SetActive(false);
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
