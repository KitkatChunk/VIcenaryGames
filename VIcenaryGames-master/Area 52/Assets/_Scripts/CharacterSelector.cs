using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    int p1 = 3;
    int p2 = 3;

    public Text guide, lockedIn;
    [Header("P1 Text")]
    public Text p1Light;
    public Text p1Medium;
    public Text p1Heavy;
    [Header("P2 Text")]
    public Text p2Light;
    public Text p2Medium;
    public Text p2Heavy;

    public void ChooseCharacter(int index)
    {
        if(p1 > 2)
        {
            p1 = index;
            PlayerPrefs.SetInt("SelectedCharacter", p1);
            TextSelect(index);
        }
        else if(p2 > 2)
        {
            p2 = index;
            PlayerPrefs.SetInt("SelectedCharacter2", p2);
            TextSelect(index);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Training");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void TextSelect(int index)
    {
        if(p2 > 2)
        {
            switch (index)
            {
                case 0:
                    p1Light.text = "P1";
                    p1Medium.text = "";
                    p1Heavy.text = "";
                    break;
                case 1:
                    p1Light.text = "";
                    p1Medium.text = "P1";
                    p1Heavy.text = "";
                    break;
                case 2:
                    p1Light.text = "";
                    p1Medium.text = "";
                    p1Heavy.text = "P1";
                    break;
            }
            guide.text = "Select Player 2";
            lockedIn.text = "Player 1 Locked-in";
        }
        else
        {
            switch (index)
            {
                case 0:
                    p2Light.text = "P2";
                    p2Medium.text = "";
                    p2Heavy.text = "";
                    break;
                case 1:
                    p2Light.text = "";
                    p2Medium.text = "P2";
                    p2Heavy.text = "";
                    break;
                case 2:
                    p2Light.text = "";
                    p2Medium.text = "";
                    p2Heavy.text = "P2";
                    break;
            }
            guide.text = "";
            lockedIn.text = "All Players Locked-in";
        }
    }
}
