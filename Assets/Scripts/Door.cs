using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    private bool onDoor = false;
    private Furgonetka doorController;

    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite[] decorations;

    [SerializeField] GameObject decoration;
    [SerializeField] TextMeshProUGUI doorNumber;

    public int number;

    private void Start()
    {
        doorController = GameObject.Find("van").GetComponent<Furgonetka>();

        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        decoration.GetComponent<SpriteRenderer>().sprite = decorations[Random.Range(0, decorations.Length)];

        while (doorController.NumberList.Contains(number) || number == 0)
        {
            number = Random.Range(100, 900);
        }
        doorController.NumberList.Add(number);

        doorNumber.text = number.ToString();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onDoor = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onDoor && GameObject.Find("Player").GetComponent<Player_Movement>().isFloored)
         {
             GameObject.Find("Player").GetComponent<Player_Movement>().hasGift = false;
                
             if (doorController.targetDoor == number)
             {
                    doorController.points += 1;
             }
         }
    }
}
