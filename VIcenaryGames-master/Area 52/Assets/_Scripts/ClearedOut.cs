using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearedOut : MonoBehaviour
{
    public GameObject transition;
    public Text rule1, rule2;
    List<GameObject> listOfEnemies = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        NoEnemies();
    }

    private void NoEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            rule1.text = "FIND THE FAR EXIT";
            rule2.text = "FIND THE FAR EXIT";
            transition.SetActive(true);
        }
    }
}
