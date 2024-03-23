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

    private void Start()
    {
        SwitchScene("Level-1");
    }

    private void SwitchScene(string scene)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneByBuildIndex(i).name == scene)
            {
                Debug.Log(SceneManager.GetSceneByBuildIndex(i));
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(i).name);
            }
        }
    }
}
