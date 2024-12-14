using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Furgonetka : MonoBehaviour
{
    private bool isInVan;
    private bool noFirstGift = true;

    public List<int> NumberList;

    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject numberDisplay;
    [SerializeField] TextMeshProUGUI numberDisplayText;

    public int targetDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInVan = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInVan = false;
    }

    private void Start()
    {
        numberDisplay.SetActive(false);
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    void Update()
    {
        if (isInVan)
        {
            if (Input.GetKeyDown(KeyCode.E) && !GameObject.Find("Player").GetComponent<Player_Movement>().hasGift)
            {
                GameObject.Find("Player").GetComponent<Player_Movement>().hasGift = true;

                targetDoor = doors[Random.Range(0, doors.Length)].gameObject.GetComponent<Door>().number;

                numberDisplay.SetActive(true);
                numberDisplayText.text = "{" + targetDoor + "}";

                if(noFirstGift)
                {
                    noFirstGift = false;
                }
            }
            else
            {
                if (!noFirstGift)
                {
                    numberDisplay.SetActive(true);
                    numberDisplayText.text = "{" + targetDoor + "}";
                }
            }
        }
        else
        {
            numberDisplay.SetActive(false);
        }

        if (GameObject.Find("Player").GetComponent<Player_Movement>().isOutside)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
