using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/// <summary>
/// This script controls the actions the player object will do
/// such as movement
/// </summary>
public class Player2Controller : MonoBehaviour
{
    public GameController gameController;
    //object of class speed from Speed.cs
    [Header("Movement Settings")]
    public Speed speed;
    public float turningSpeed;

    [Header("Attack Settings")]
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;

    //fireRate counter
    private float myTime;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //Delta Time represents the amount of time elapsed since the last update() call
        myTime += Time.deltaTime;
        //calls Move method
        Move();
        Attack();
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
        if (Input.GetButton("Fire1_2") && myTime > fireRate)
        {
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            myTime = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameController.Reset();
        }
    }
}
