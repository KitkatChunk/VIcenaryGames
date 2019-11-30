using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //[Header("Scoreboard")]
    //[SerializeField]
    //private int _health1;
    //private int _health2;

    //[SerializeField]
    //private int _score1;
    //private int _score2;

    //public Text healthLabel1;
    //public Text healthLabel2;
    //public Text scoreLabel1;
    //public Text scoreLabel2;
    //public Text highScoreLabel;

    //[Header("Game Settings")]
    //public ScoreBoard scoreBoard;


    //Start is called before the first frame update
    //void Start()
    //{
    //    if (SceneManager.GetActiveScene().name == "LevelOne")
    //    {
    //        Health1 = 100;
    //        Health2 = 100;
    //        Score1 = 0;
    //        Score2 = 0;
    //    }

    //    healthLabel1.text = "Lives: " + scoreBoard.health1;
    //    healthLabel2.text = "Lives: " + scoreBoard.health2;
    //    scoreLabel1.text = "Score: " + scoreBoard.score1;
    //    scoreLabel2.text = "Score: " + scoreBoard.score2;
    //    highScoreLabel.text = "High Score: " + scoreBoard.highScore;
    //}

    //Update is called once per frame
    //void Update()
    //{

    //}

    //health 1
    //public int Health1
    //{
    //    get
    //    {
    //        return _health1;
    //    }
    //    set
    //    {
    //        _health1 = value;
    //        scoreBoard.health1 = _health1;

    //        if (_health1 < 1)
    //        {

    //            SceneManager.LoadScene("GameOver");
    //        }
    //        else
    //        {
    //            healthLabel1.text = "Health: " + _health1;
    //        }
    //    }

    //}

    ////health 2
    //public int Health2
    //{
    //    get
    //    {
    //        return _health2;
    //    }
    //    set
    //    {
    //        _health2 = value;
    //        scoreBoard.health2 = _health2;

    //        if (_health2 < 1)
    //        {

    //            SceneManager.LoadScene("GameOver");
    //        }
    //        else
    //        {
    //            healthLabel1.text = "Health: " + _health2;
    //        }
    //    }

    //}

    ////score 1
    //public int Score1
    //{
    //    get
    //    {
    //        return _score1;
    //    }

    //    set
    //    {
    //        _score1 = value;
    //        scoreBoard.score1 = _score1;

    //        if (scoreBoard.highScore < _score1)
    //        {
    //            scoreBoard.highScore = _score1;
    //        }
    //        scoreLabel1.text = "Score: " + _score1;
    //    }
    //}

    ////score 2
    //public int Score2
    //{
    //    get
    //    {
    //        return _score2;
    //    }

    //    set
    //    {
    //        _score2 = value;
    //        scoreBoard.score2 = _score2;

    //        if (scoreBoard.highScore < _score2)
    //        {
    //            scoreBoard.highScore = _score2;
    //        }
    //        scoreLabel2.text = "Score: " + _score2;
    //    }
    //}


    //private void GameObjectInitialization()
    //{
    //    scoreBoard = Resources.FindObjectsOfTypeAll<ScoreBoard>()[0] as ScoreBoard;
    //}


    //private void SceneConfiguration()
    //{
    //    //if (SceneManager.GetActiveScene().name == "LevelOne")
    //    //{
    //    //    Health1 = 100;
    //    //    Health2 = 100;
    //    //    Score1 = 0;
    //    //    Score2 = 0;
    //    //}

    //    //healthLabel1.text = "Lives: " + scoreBoard.health1;
    //    //healthLabel2.text = "Lives: " + scoreBoard.health2;
    //    //scoreLabel1.text = "Score: " + scoreBoard.score1;
    //    //scoreLabel2.text = "Score: " + scoreBoard.score2;
    //    //highScoreLabel.text = "High Score: " + scoreBoard.highScore;

    //}


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
}
