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
    public int lives;

    public Transform groundCheck;
    public Text scoreText;
    public Text livesText;
    public string playerName;

    private bool grounded = false;
    private Rigidbody2D rb2d;

    private DataController dataController;
    private bool isClicked = false;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        InvokeRepeating("IncrementScore", 1, 1);
    }

    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
        isClicked = false;
        playerName = "Player 1";
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
        
}