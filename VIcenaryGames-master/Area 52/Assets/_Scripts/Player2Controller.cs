using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls the actions the player object will do
/// such as movement
/// </summary>
public class Player2Controller : MonoBehaviour
{
    public GameController gameController;

    [SerializeField]
    private static int _health2;
    public Text HealthLabel;

    [SerializeField]
    private static int _score2;
    public Text ScoreLabel;

    //object of class speed from Speed.cs
    [Header("Movement Settings")]
    public Speed speed;
    public float turningSpeed;

    [Header("Attack Settings")]
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;

    [Header("Game Settings")]
    public ScoreBoard2 scoreBoard;

    [Header("Player Sprites")]
    private SpriteRenderer spriteRenderer;
    public Sprite blue;
    public Sprite green;
    public Sprite red;

    //fireRate counter
    private float myTime;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("SelectedCharacter2") == 0)
        {
            spriteRenderer.sprite = blue;
            Health = 20;
            speed.min = -0.08f;
            speed.max = 0.08f;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter2") == 1)
        {
            spriteRenderer.sprite = green;
            Health = 50;
            speed.min = -0.06f;
            speed.max = 0.06f;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter2") == 2)
        {
            spriteRenderer.sprite = red;
            Health = 80;
            speed.min = -0.04f;
            speed.max = 0.04f;
        }
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            Score = 0;
        }
        else
        {
            Health = scoreBoard.health2;
            Score = scoreBoard.score2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Delta Time represents the amount of time elapsed since the last update() call
        myTime += Time.deltaTime;
        //calls Move method
        Move();
        Attack();
        Score = Destroyer.p2;
    }

    public int Health
    {
        get
        {
            return _health2;
        }
        set
        {
            _health2 = value;
            scoreBoard.health2 = _health2;

            if (_health2 < 1)
            {

                SceneManager.LoadScene("End");
            }
            else
            {
                HealthLabel.text = "Health: " + _health2;
            }
        }
    }

    // Score counter and updater 
    public int Score
    {
        get
        {
            return _score2;
        }
        set
        {
            _score2 = value;
            scoreBoard.score2 = _score2;

            if (scoreBoard.highScore < _score2)
            {
                scoreBoard.highScore = _score2;
            }
            ScoreLabel.text = "Score: " + _score2;
        }
    }

    public void Move()
    {
        //FOR ROTATION
        Quaternion newRotation = transform.rotation;
        float z = newRotation.eulerAngles.z;

        //if player enters "right" or "left", turn towards that direction
        z -= Input.GetAxis("Horizontal_2") * turningSpeed;
        newRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = newRotation;

        //FOR MOVEMENT
        Vector3 newPosition = transform.position;

        //if player enters "up", move forward
        if (Input.GetAxis("Vertical_2") > 0.0f)
        {
            //sets transformation/movement speed (and takes into account the rotation in it's movement)
            Vector3 velocity = new Vector3(0.0f, speed.max, 0.0f);
            newPosition += newRotation * velocity;
        }

        //if player enters "down", move back
        if (Input.GetAxis("Vertical_2") < 0.0f)
        {
            //sets transformation/movement speed (and takes into account the rotation in it's movement)
            Vector3 velocity = new Vector3(0.0f, speed.min, 0.0f);
            newPosition += newRotation * velocity;
        }
        transform.position = newPosition;
    }

    public void Attack()
    {
        if (Input.GetButton("Fire1_2") && myTime >= fireRate)
        {
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            myTime = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Health -= 10;
            Score -= 50;
            if (Health <= 0)
            {
                gameController.Reset();
            }
        }
    }

    // Increase speed when player "picks up" powerup
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            Health -= 10;
            Destroy(other.gameObject);
            if (Health <= 0)
            {
                gameController.Reset();
            }
        }
        // Increase speed when player "picks up" powerup
        if (other.gameObject.tag == "PowerUp")
        {
            StartCoroutine(PowerUpWearOff(3f));
        }
        // Increase Health when player "picks up" powerup
        if (other.gameObject.tag == "Health")
        {
            Health += 30;
        }
    }
    //Limits the time of the powerup
    IEnumerator PowerUpWearOff(float waitTime)
    {
        speed.max += 0.04f;
        yield return new WaitForSeconds(waitTime);
        speed.max -= 0.04f;
    }
}
