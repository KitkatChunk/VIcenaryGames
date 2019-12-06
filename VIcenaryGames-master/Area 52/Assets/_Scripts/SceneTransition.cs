using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] public string nextLevel;
    public Text coop1, coop2;
    private bool isready, isready2, bothready;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player 1")
        {
            coop1.text = "Waiting for Player 2";
            coop2.text = "Waiting for Player 2";
            isready = true;
        }
        if (other.name == "Player 2")
        {
            coop1.text = "Waiting for Player 1";
            coop2.text = "Waiting for Player 1";
            isready2 = true;
        }
        if (isready && isready2)
        {
            coop1.text = "";
            coop2.text = "";
            SceneManager.LoadScene(nextLevel);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player 1")
        {
            coop1.text = "";
            coop2.text = "";
            isready = false;
        }
        if (other.name == "Player 2")
        {
            coop1.text = "";
            coop2.text = "";
            isready2 = false;
        }
    }
}
