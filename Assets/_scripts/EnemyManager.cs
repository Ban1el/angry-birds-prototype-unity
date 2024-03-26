using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int enemyCounter;

    private void CheckHowManyEnemiesLeft()
    {
        if (enemyCounter <= 0)
        {
            Actions.OnWin?.Invoke();
        }
    }

    private void AddEnemyCounter()
    {
        enemyCounter++;
    }

    private void EnemyDied()
    {
        enemyCounter--;
    }

    private void OnEnable()
    {
        Actions.OnAddEnemyCounter += AddEnemyCounter;
        Actions.OnEnemyDeath += EnemyDied;
        Actions.OnEnemyDeath += CheckHowManyEnemiesLeft;
    }
    private void OnDisable()
    {
        Actions.OnAddEnemyCounter -= AddEnemyCounter;
        Actions.OnEnemyDeath -= EnemyDied;
        Actions.OnEnemyDeath -= CheckHowManyEnemiesLeft;
    }
}
