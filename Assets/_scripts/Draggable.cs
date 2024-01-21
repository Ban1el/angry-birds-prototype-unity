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

    [SerializeField]
    private Transform origin_point;

    [SerializeField]
    private float delay_to_origin_speed;
    private bool mouse_released = true;

    private void Start()
    {
        spawn_position = transform.position;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin_point.position, area_radius);
    }
}
