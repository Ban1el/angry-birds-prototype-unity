using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    public static Action OnChangeBullet;
    public static Func<Transform> OriginPointPosition;
    public static Action OnGameOver;
    public static Action OnWin;

    //Enemy
    public static Action OnAddEnemyCounter;
    public static Action OnEnemyDeath;

    //UI
    //1P: Button Type
    //2P: Button name
    public static Action<string, string> OnButtonClick;
    //Enable UI
    //1p: UI name
    public static Action<string> OnEnableUI;

    //Developer tools
    public static Action OnKillAllEnemies;
}
