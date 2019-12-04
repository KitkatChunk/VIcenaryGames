using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    public Transform wallAhead;
    public bool hasWallAhead;
    public bool isMovingPositive = true; //true = moving right/up, false = moving left/down
    public bool isHorizontal; //defining variable for if movement is on x or y axis (horizontal or vertical)
    public float speed;

    [Header("Attack Settings")]
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    private float downTime;




    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        downTime += Time.deltaTime;
        Move();
        Attack();
    }

    public void Move()
    {
        hasWallAhead = Physics2D.Linecast(
            transform.position,
            wallAhead.position,
            1 << LayerMask.NameToLayer("Boundary"));

        if (isHorizontal)
        {
            if (isMovingPositive)
            {
                enemyRigidBody.velocity = new Vector2(speed, 0.0f);
            }

            if (!isMovingPositive)
            {
                enemyRigidBody.velocity = new Vector2(-speed, 0.0f);
            }

            if (hasWallAhead)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 0.5f, 1.0f);
                isMovingPositive = !isMovingPositive;
            }
        }

        if (!isHorizontal)
        {
            if (isMovingPositive)
            {
                enemyRigidBody.velocity = new Vector2(0.0f, speed);
                shotSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (!isMovingPositive)
            {
                enemyRigidBody.velocity = new Vector2(0.0f, -speed);
                shotSpawn.transform.rotation = Quaternion.Euler(180, 0, 0);
            }

            if (hasWallAhead)
            {
                transform.localScale = new Vector3(0.5f, -transform.localScale.y, 1.0f);
                isMovingPositive = !isMovingPositive;
            }
        }
    }

    public void Attack()
    {
        if (downTime >= fireRate)
        {
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            downTime = 0.0f;
        }
    }

}