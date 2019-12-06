using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public void Reset()
    {
        SceneManager.LoadScene("Training");
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void OnClearButtonClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void LastLevel()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Death()
    {
        SceneManager.LoadScene("End");
    }
}
