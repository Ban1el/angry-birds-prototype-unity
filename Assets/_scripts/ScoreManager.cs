using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    private void AddPoints(int points)
    {
        score += points;
        Actions.OnSetUIText?.Invoke(score.ToString(), "score");
    }

    private void OnEnable()
    {
        Actions.OnGetPoints += AddPoints;
    }

    private void OnDisable()
    {
        Actions.OnGetPoints -= AddPoints;
    }
}
