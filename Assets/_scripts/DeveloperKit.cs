using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperKit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Kill all enemies
            Actions.OnKillAllEnemies?.Invoke();
        }
    }
}
