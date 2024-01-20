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

    private void Start()
    {
        spawn_position = transform.position;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        difference = mousePos - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 origin_position_2d = (Vector2)origin_point.position;
        Vector2 desired_position = mousePos - difference;
        Vector2 clampedPosition =
            origin_position_2d
            + Vector2.ClampMagnitude(desired_position - origin_position_2d, area_radius);
        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        transform.position = spawn_position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin_point.position, area_radius);
    }
}
