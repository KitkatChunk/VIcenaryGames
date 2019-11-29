using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreBoard2", menuName = "Game/ScoreBoard2")]
[System.Serializable]
public class ScoreBoard2 : ScriptableObject
{
    public int highScore;
    public int health2;
    public int score2;
}