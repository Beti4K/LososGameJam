using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    [SerializeField] Sprite[] wallpaper;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = wallpaper[Random.Range(0, wallpaper.Length)];
    }

}
