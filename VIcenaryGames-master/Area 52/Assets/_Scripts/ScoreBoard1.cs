using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreBoard1", menuName = "Game/ScoreBoard1")]
[System.Serializable]
public class ScoreBoard1 : ScriptableObject
{
    public int highScore;
    public int health1;
    public int score1;   
}
