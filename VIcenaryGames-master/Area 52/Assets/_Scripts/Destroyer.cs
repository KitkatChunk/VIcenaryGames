using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
     //public Player1Controller player1;
    //public Player2Controller player2;

    public static int p1 =0;
    public static int p2 =0;
   // public GameObject player1;
    //Start is called before the first frame update
    //void Start()
    //{
    //    GameObject Player1 = GameObject.Find("Player1");
    //    Player1Controller player1 = Player1.GetComponent<Player1Controller>();
    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boundary" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall")
        {
            p1 += 100;
            p2 += 100;
            //Debug.Log("ello " + p1);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
