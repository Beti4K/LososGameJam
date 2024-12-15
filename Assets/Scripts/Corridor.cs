using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    [SerializeField] Sprite[] wallpaper;
    [SerializeField] Sprite[] spritesFront;

    [SerializeField] GameObject front;
    [SerializeField] GameObject back;
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
            back.SetActive(false);
        }
        else
        {
            front.SetActive(false);
            back.SetActive(true);
        }
    }
}
