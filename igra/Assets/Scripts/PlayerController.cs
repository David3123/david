using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver = false;
    public BoxCollider2D collider;
    public float time;
    private float _timeLeft = 0f;
    public bool _timeron = false;
    public GameObject GameOverPanel, scoreText;
    public Text FinalScoreText, HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        _timeLeft = time;
        _timeron = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }

        if(jumpCount == 2)
        {
            canJump = false;
        }

        if (Input.GetKeyDown("space") && canJump && !isGameOver)
        {
            rb2d.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }

        if (Input.GetKeyDown("c") && !isGameOver)
        {
            anim.SetTrigger("slait");
        }
        else
        {
            collider.size = new Vector2(collider.size.x, 5.0f);
            collider.offset = new Vector2(collider.offset.x, 0);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("slait"))
        {
            collider.size = new Vector2(collider.size.x, 1.5f);
            collider.offset = new Vector2(collider.offset.x, -1.5f);
        }

        if (_timeron)
        {
            if (_timeLeft > 0)
            {
                runSpeed = 16;
                _timeLeft -= Time.deltaTime;
            }
            else
            {
                runSpeed = 8;
                _timeLeft = time;
                _timeron = false;
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        anim.SetTrigger("death");

        StartCoroutine("ShowGameOverPanel");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text = "Score : " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }
}
