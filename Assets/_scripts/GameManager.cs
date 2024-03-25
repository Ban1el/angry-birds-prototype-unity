using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game_manager;
    public string level;

    private void Awake()
    {
        if (game_manager == null)
        {
            game_manager = this;
        }
        else if (game_manager != this)
        {
            Destroy(gameObject);
        }
    }

    private void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void StartButtonPressed(string buttonType, string buttonName) 
    {
        if (buttonType == "main menu" && buttonName =="start")
        {
            SwitchScene("Level-1");
        }
    }

    private void OnEnable()
    {
        Actions.OnButtonClick += StartButtonPressed;
    }

    private void OnDisable()
    {
        Actions.OnButtonClick -= StartButtonPressed;
    }
}
