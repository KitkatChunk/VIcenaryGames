using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        Vector2 newPosition = new Vector2(speed, 0.0f);
        Vector2 currentPosition = transform.position;
        currentPosition += newPosition;
        transform.position = currentPosition;
    }

    void CheckBounds()
    {
        if(transform.position.x >= 5.4f || transform.position.x <= -5.4f)
        {
            speed = -speed;
        }
    }
}
