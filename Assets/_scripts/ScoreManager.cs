using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void AddPoints(int points)
    {
        Actions.OnSetUIText?.Invoke(points.ToString(), "score");
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
