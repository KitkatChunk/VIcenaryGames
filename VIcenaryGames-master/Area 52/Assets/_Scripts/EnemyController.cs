using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    public Transform wallAhead;
    public bool hasWallAhead;
    public bool isMovingRight = true;
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

        if (isMovingRight)
        {
            enemyRigidBody.velocity = new Vector2(speed, 0.0f);
        }

        if (!isMovingRight)
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0.0f);
        }

        if (hasWallAhead)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 0.5f, 1.0f);
            isMovingRight = !isMovingRight;
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