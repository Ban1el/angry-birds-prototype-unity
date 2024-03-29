using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // The hit force needed before the enemy is destroyed.
    [SerializeField]
    private float impact_hit_force = 10f;

    private void Start()
    {
        Actions.OnAddEnemyCounter?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= impact_hit_force)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Actions.OnEnemyDeath?.Invoke();
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Actions.OnKillAllEnemies += KillEnemy;
    }

    private void OnDisable()
    {
        Actions.OnKillAllEnemies -= KillEnemy;
    }
}
