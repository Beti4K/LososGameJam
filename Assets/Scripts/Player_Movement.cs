using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool isGameActive;
    public float horizontal;

    private bool isFloored;
    public bool hasGift;
    public bool isOutside;

    [SerializeField] float force;
    [SerializeField] float speed;

    [SerializeField] GameObject loseScreen;

    void Start()
    {
        isGameActive = true;
        isFloored = true;
    }

    void Update()
    {
        if (isGameActive)
        {
            horizontal = Input.GetAxis("Horizontal");

            transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);

            if (isFloored && isGameActive)
            {
                GetComponent<Animator>().SetBool("isFloored", true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    isFloored = false;
                    GetComponent<Animator>().SetBool("isFloored", false);
                }
            }
        }

        if (horizontal > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else if (horizontal < 0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }

        if (hasGift)
        {
            GetComponent<Animator>().SetBool("hasGift", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("hasGift", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloored = true;
        }
    }

    public void LevelLose()
    {
        isGameActive = false;

        GetComponent<Animator>().SetBool("isEnd", true);
        loseScreen.SetActive(true);
    }
}
