using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // The hit force needed before the enemy is destroyed.
    [SerializeField]
    private float impact_hit_force = 10f;

    [SerializeField]
    private int points = 5000;

    [SerializeField]
    private GameObject scoreUIPrefab;

    private void Start()
    {
        Actions.OnAddEnemyCounter?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= impact_hit_force)
        {
            KillEnemy();
        }
    }

    private void OnDestroy()
    {
        Actions.OnEnemyDeath?.Invoke();
    }

    private void KillEnemy()
    {
        GameObject trans = Instantiate(scoreUIPrefab, this.transform.position, Quaternion.identity);
        TextMeshProUGUI scoreUI = trans.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        scoreUI.text = points.ToString();

        Actions.OnGetPoints?.Invoke(points);
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
