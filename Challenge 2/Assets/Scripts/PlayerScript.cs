using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    public Text lifeText;

    public Text winLoseText;

    public AudioClip musicClipBack;

    public AudioClip musicClipWin;

    public AudioClip musicClipLose;

    public AudioSource musicSource;



    private int scoreValue = 0;

    private int lives = 3;

    private int level = 1;

    private int winState = 0;

    private bool facingRight = true;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Coins:" + scoreValue.ToString() + "/4";
        lifeText.text = "Lives: " + lives.ToString() + "/3";
        anim = GetComponent<Animator>();
        musicSource.clip = musicClipBack;
        musicSource.Play();
        winLoseText.text = "";
    }


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()

    {



        lifeText.text = "Lives: " + lives.ToString() + "/3";
        score.text = "Coins:" + scoreValue.ToString() + "/4";
        float moveHorizontal = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(moveHorizontal * speed, vertMovement * speed));

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

        if ( lives == 0)
            {
            winLoseText.text = "YOU DIED\nPress 'R' to try again\n Press 'ESCAPE' to quit";
            Destroy(gameObject);
        }



        if (level == 1)
        {
            if (scoreValue == 4)
            {
                winState = 1;
                musicSource.Stop();
                musicSource.clip = musicClipWin;
                musicSource.Play();

            }

            if (winState == 1)
            { 

                scoreValue = 0;



                winLoseText.text = "Level 1 complete press 'ENTER' to go to level 2!";
                if ((Input.GetKey("return")))

                {
                    lives = 3;
                    winState = 0;
                    musicSource.clip = musicClipBack;
                    musicSource.Play();
                    transform.position = new Vector2(-39f, -23.5f);
                    level = 2;
                    winLoseText.text = "";
                }
            }
        }
        if (level == 2)
            {
            if (scoreValue == 4)
                {
                    winState = 1;

                    musicSource.Stop();

                    musicSource.clip = musicClipWin;

                    musicSource.Play();
                }

            if (winState == 1)
                {
  

                    scoreValue = 0;

                     winLoseText.text = "You have won the game!\nPress 'R' to play again\nPress 'ESCAPE' to quit\nCreated by Randall Forehand";
                }
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Coins:" + scoreValue.ToString() + "/4";
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            lives = lives - 1;
            lifeText.text = "Lives: " + lives.ToString() + "/3";


        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool("Jump", false);

            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
            }
        }
    }
}
