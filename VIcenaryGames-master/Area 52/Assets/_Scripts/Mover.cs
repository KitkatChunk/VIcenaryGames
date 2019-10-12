using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    //Variable Declaration
    public float speed;

    private Rigidbody2D rBody;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.up * speed;
        //transform.up and transform.forward affect the other axis'
    }
}
