using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginPoint : MonoBehaviour
{
    private Transform Origin_Point()
    {
        return this.transform;
    }

    private void OnEnable()
    {
        Actions.OriginPointPosition += Origin_Point;
    }
    private void OnDisable()
    {
        Actions.OriginPointPosition -= Origin_Point;
    }
}
