using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isActive = true;
    private Draggable drag;
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject scoreUIPrefab;

    private void Awake()
    {
        drag = GetComponent<Draggable>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (drag.shot)
        {
            if (rb.velocity.x <= 0 && rb.velocity.y <= 0 && isActive)
            {
                drag.enabled = false;
                isActive = false;
                Actions.OnChangeBullet?.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            int points = Mathf.RoundToInt(collision.gameObject.GetComponent<Obstacle>().pointMultiplier * collision.relativeVelocity.magnitude);
            GameObject trans = Instantiate(scoreUIPrefab, this.transform.position, Quaternion.identity);
            TextMeshProUGUI scoreUI = trans.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            scoreUI.text = points.ToString();
            Actions.OnGetPoints?.Invoke(points);
        }
    }
}
