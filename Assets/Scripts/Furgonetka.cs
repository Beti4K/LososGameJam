using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Furgonetka : MonoBehaviour
{
    private bool isInVan;

    public List<int> NumberList;

    [SerializeField] GameObject[] doors;

    [SerializeField] Player_Movement player;

    [SerializeField] GameObject numberDisplay;
    [SerializeField] TextMeshProUGUI numberDisplayText;

    [SerializeField] GameObject giftDisplay;
    [SerializeField] TextMeshProUGUI giftsLeftText;

    [SerializeField] GameObject wheels;
    [SerializeField] GameObject chopaki;

    [SerializeField] GameObject winScreen;

    [SerializeField] int maxPoints;

    public int targetDoor;
    public int points;

    private void Start()
    {
        numberDisplay.SetActive(false);
        giftDisplay.SetActive(false);
        points = 0;
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInVan = true;

        numberDisplay.SetActive(true);
        giftDisplay.SetActive(true);

        numberDisplayText.text = targetDoor.ToString();
        giftsLeftText.text = points + "/" + maxPoints;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInVan = false;

        numberDisplay.SetActive(false);
        giftDisplay.SetActive(false);
    }

    void Update()
    {
        if (isInVan && !player.hasGift)
        {
            player.hasGift = true;

            targetDoor = doors[Random.Range(0, doors.Length)].gameObject.GetComponent<Door>().number;

            numberDisplayText.text = targetDoor.ToString();
            giftsLeftText.text = points + "/" + maxPoints;
        }

        if (player.isOutside)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            wheels.GetComponent<SpriteRenderer>().enabled = true;
            chopaki.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            wheels.GetComponent<SpriteRenderer>().enabled = false;
            chopaki.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (points == maxPoints)
        {
            LevelWin();
        }
    }

    private void LevelWin()
    {
        winScreen.SetActive(true);
    }
}
