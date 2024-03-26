using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    List<UIController> UserInterfaces = new List<UIController>();

    private void Awake()
    {
        UIController[] controllers = GetComponentsInChildren<UIController>(true);
        UserInterfaces.AddRange(controllers);
    }

    private void Start()
    {
        DisableUIAll();
    }

    private void DisableUIAll()
    {
        foreach (UIController controller in UserInterfaces)
        {
            controller.gameObject.SetActive(false);
        }
    }

    private void TurnOnUI(string UIName)
    {
        foreach (UIController controller in UserInterfaces)
        {
            if (controller.UIName == UIName)
            {
                controller.gameObject.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        Actions.OnEnableUI += TurnOnUI;
    }

    private void OnDisable()
    {
        Actions.OnEnableUI -= TurnOnUI;
    }
}
