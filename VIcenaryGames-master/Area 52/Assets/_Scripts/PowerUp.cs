using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        source.Play();
        Destroy(gameObject);
    }


}
