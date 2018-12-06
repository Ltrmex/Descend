using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public int score;
    public static int lives;
    public int coins;

    public Transform groundCheck;
    public Text scoreText;
    public Text livesText;
    public Text coinsText;
    public string playerName;

    private bool grounded = false;
    private Rigidbody2D rb2d;

    private DataController dataController;
    private bool isClicked = false;

    public AudioClip hurtSound;
    public AudioSource hurtSource;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        InvokeRepeating("IncrementScore", 1, 1);
    }

    private void Start()
    {
        if (SetDifficulty.difficulty == "Medium")
            lives = 2;
        else if (SetDifficulty.difficulty == "Hard")
            lives = 1;
        else
            lives = 3;

        livesText.text = "Lives: " + lives.ToString();
        dataController = FindObjectOfType<DataController>();
        isClicked = false;
        playerName = "Player 1";
        hurtSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (isClicked)
            dataController.Submit(playerName, SetDifficulty.difficulty, score);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void IncrementScore() {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GetInput(string playerName)
    {
        this.playerName = playerName;
    }   //  GetInput()

    public void Clicked() {
        isClicked = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Coin"){
            coins++;
            coinsText.text = "Coins: " + coins.ToString();

            if (coins > 10) {
                lives++;
                livesText.text = "Lives: " + lives.ToString();
                coins = 0;
            }

            Destroy(col.gameObject);
        }

        if (col.tag == "Enemy") {
            hurtSource.PlayOneShot(hurtSound);
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            Destroy(col.gameObject);
        }
    }

}