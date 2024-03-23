using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isDead = false;
    private Draggable drag;
    private Rigidbody2D rb;

    private void Awake()
    {
        drag = GetComponent<Draggable>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsDead();
    }

    private void IsDead()
    {
        if (drag.shoot)
        {
            if (rb.velocity.x <= 0 && rb.velocity.y <= 0 && !isDead)
            {
                isDead = true;
                drag.enabled = false;
                Actions.OnChangeBullet?.Invoke();
            }
        }
    }
}
