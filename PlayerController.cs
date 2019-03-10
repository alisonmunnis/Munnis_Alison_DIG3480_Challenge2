using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private int score;
    private int lives;

    public GameObject player;
    public float speed;
    public float jumpForce;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;
   


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetAllText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetAllText();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1; // this removes 1 from the score
            SetAllText();
        }

        if (score == 4)
        {

            transform.position = new Vector3(49.5f, 0.5f, 0.0f);
            lives = 3;

        }

        if (lives == 0)
        {
            Destroy(player);
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        }
    }

void SetAllText()
{
    scoreText.text = "Score: " + score.ToString();
    if (score >= 8)
    {
            winText.text = "You Win!";
    }

    livesText.text = "Lives: " + lives.ToString();
    if (lives == 0)
    {
        loseText.text = "You Lose!";
    }
}

}