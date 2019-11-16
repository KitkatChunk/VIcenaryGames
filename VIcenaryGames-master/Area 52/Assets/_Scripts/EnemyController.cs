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

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        Move();
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
}
