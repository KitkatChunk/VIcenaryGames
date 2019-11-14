using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
