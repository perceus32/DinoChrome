using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dino : MonoBehaviour
{
    public Animator anim;
    public Text score, highScore;
    public int gameScore = 0;
    public float upForce;
    public Rigidbody2D rb;
    public bool isInAir = false;
    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        rb.AddForce(Vector2.up * upForce * Time.deltaTime);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGameOver)
        {
            gameScore++;
            score.text = gameScore.ToString();

        }
        if (gameScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", gameScore);
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
               
        //Debug.Log(isGameOver);
        if (isGameOver) return;
        //Debug.Log(isInAir);
        if (Input.GetKeyDown(KeyCode.Space) && !isInAir)
        {
            Debug.Log("jumped yay");
            rb.AddForce(new Vector2(0, upForce) * Time.deltaTime, ForceMode2D.Impulse/**rb.gravityScale*/);
            anim.SetBool("Jump", true);
            isInAir = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInAir = false;
            anim.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("Dead"))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        FindObjectOfType<obstacleSpawn>().GameOver();
        FindObjectOfType<move>().xVel = 0;
        FindObjectOfType<moveCloud>().xVel = 0;
        FindObjectOfType<score>().GameOver();
        anim.SetBool("GameOver", true);
    }
}
