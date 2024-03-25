using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    public static Action OnChangeBullet;
    public static Func<Transform> OriginPointPosition;

    //UI
    //1P: Button Type
    //2P: Button name
    public static Action<string, string> OnButtonClick;
}
