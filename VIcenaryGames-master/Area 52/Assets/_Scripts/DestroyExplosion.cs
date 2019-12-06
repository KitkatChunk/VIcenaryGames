using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public void DestroyThis()
    {
        //destroy explosion
        Destroy(this.gameObject);
    }
}
