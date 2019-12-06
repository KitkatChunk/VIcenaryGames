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
public class Player1Controller : MonoBehaviour
{
    public GameController gameController;

    [SerializeField]
    private static int _health1;
    public Text HealthLabel;

    [SerializeField]
    private static int _score1;
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
    public ScoreBoard1 scoreBoard;

    [Header("Player Sprites")]
    private SpriteRenderer spriteRenderer;
    public Sprite blue;
    public Sprite green;
    public Sprite red;

    [Header("Explosion settings")]
    public GameObject explosion1;
    public GameObject explosion3;
 

    //fireRate counter
    private float myTime;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("SelectedCharacter") == 0)
        {
            spriteRenderer.sprite = blue;
            Health = 20;
            speed.min = -0.08f;
            speed.max = 0.08f;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter") == 1)
        {
            spriteRenderer.sprite = green;
            Health = 50;
            speed.min = -0.06f;
            speed.max = 0.06f;
        }

        if (PlayerPrefs.GetInt("SelectedCharacter") == 2)
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
            Health = scoreBoard.health1;
            Score = scoreBoard.score1;
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
        Score = Destroyer.p1;
    }

    public int Health
    {
        get
        {
            return _health1;
        }
        set
        {
            _health1 = value;
            scoreBoard.health1 = _health1;

            if (_health1 < 1)
            {

                SceneManager.LoadScene("GameOver");
            }
            else
            {
                HealthLabel.text = "Health: " + _health1;
            }

        }
    }

    // Score counter and updater
    public int Score
    {
        get
        {
            return _score1;
        }
        set
        {
            _score1 = value;
            
            scoreBoard.score1 = _score1;

            if (scoreBoard.highScore < _score1)
            {
                scoreBoard.highScore = _score1;
            }
            ScoreLabel.text = "Score: " + _score1;
        }
    }

    public void Move()
    {
        //FOR ROTATION
        Quaternion newRotation = transform.rotation;
        float z = newRotation.eulerAngles.z;

        //if player enters "right" or "left", turn towards that direction
        z -= Input.GetAxis("Horizontal") * turningSpeed;
        newRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = newRotation;

        //FOR MOVEMENT
        Vector3 newPosition = transform.position;

        //if player enters "up", move forward
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            //sets transformation/movement speed (and takes into account the rotation in it's movement)
            Vector3 velocity = new Vector3(0.0f, speed.max, 0.0f);
            newPosition += newRotation * velocity;
        }

        //if player enters "down", move back
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            //sets transformation/movement speed (and takes into account the rotation in it's movement)
            Vector3 velocity = new Vector3(0.0f, speed.min, 0.0f);
            newPosition += newRotation * velocity;
        }
        transform.position = newPosition;
    }

    public void Attack()
    {
        if (Input.GetButton("Fire1") && myTime >= fireRate)
        {
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            myTime = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
          //  Instantiate(explosion3, other.transform.position, other.transform.rotation);
          //  Instantiate(explosion1, this.transform.position, this.transform.rotation);
            Health -= 10;
            Score -= 50;
            if (Health <= 0)
            {
                gameController.Reset();

            }
        }
    }
   
     void OnTriggerEnter2D(Collider2D other)
     {
        if(other.gameObject.tag == "EnemyBullet")
        {
            Health -= 10;
            Destroy(other.gameObject);
            Instantiate(explosion1, this.transform.position, this.transform.rotation);
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

        if(other.gameObject.tag =="Enemy")
        {
            Instantiate(explosion3, other.transform.position, other.transform.rotation);
            Instantiate(explosion1, this.transform.position, this.transform.rotation);
        }

     }

    //Limits the time of the powerup
    IEnumerator PowerUpWearOff(float waitTime)
    {
        speed.max += 0.04f;
        speed.min -= 0.04f;
        yield return new WaitForSeconds(waitTime);
        speed.max -= 0.04f;
        speed.min += 0.04f;
    }
}
