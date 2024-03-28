using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{
    [SerializeField]
    private float pointMultiplier = 50f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the other object has the tag "Player"
        if (other.gameObject.CompareTag("bullet"))
        {
            int points = Mathf.RoundToInt(other.relativeVelocity.magnitude * pointMultiplier);
            Actions.OnGetPoints?.Invoke(points);
        }
    }
}
