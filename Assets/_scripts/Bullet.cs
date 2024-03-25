using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isActive = true;
    private Draggable drag;
    private Rigidbody2D rb;

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
}
