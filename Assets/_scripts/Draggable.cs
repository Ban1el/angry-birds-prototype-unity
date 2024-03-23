using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private Vector2 mousePos;
    private Vector2 spawn_position;

    [SerializeField]
    private float area_radius;

    private Transform origin_point;

    [SerializeField]
    private float delay_to_origin_speed;
    private bool mouse_released = true;
    private Rigidbody2D rb;

    [SerializeField]
    private float force_multiplier = 6f;
    public bool shoot = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spawn_position = transform.position;
        origin_point = Actions.OriginPointPosition();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void ReturnToOriginPoint()
    {
        if (mouse_released)
        {
            transform.position = Vector2.Lerp(
                transform.position,
                origin_point.position,
                delay_to_origin_speed * Time.deltaTime
            );
        }
    }

    private void OnMouseDown()
    {
        difference = mousePos - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        mouse_released = false;
        Vector2 origin_position_2d = (Vector2)origin_point.position;
        Vector2 desired_position = mousePos - difference;
        Vector2 clampedPosition =
            origin_position_2d
            + Vector2.ClampMagnitude(desired_position - origin_position_2d, area_radius);
        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        mouse_released = true;
        shoot = true;

        // Calculate the force direction
        Vector2 forceDirection = (origin_point.position - transform.position).normalized;

        // Calculate the force based on the distance
        float distance = Vector2.Distance(transform.position, origin_point.position);
        rb.gravityScale = 1f;

        // Apply the force to the object's Rigidbody
        rb.AddForce(forceDirection * (distance * force_multiplier), ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        if (origin_point != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(origin_point.position, area_radius);
        }
    }
}
