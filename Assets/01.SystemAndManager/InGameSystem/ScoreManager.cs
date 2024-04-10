using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    public int score;
    public static int totalScore;

    public void AddScore(int value)
    {
        score += value;
    }

    public void AddTotalScore()
    {
        totalScore += score;
    }
}
