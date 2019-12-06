using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private AudioSource source;
    private SpriteRenderer render;
    private BoxCollider2D collide;

    void Start()
    {
        source = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
        collide = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            source.Play();
            render.enabled = false;
            collide.enabled = false;
            //Destroy(gameObject);
        }
    }


}
