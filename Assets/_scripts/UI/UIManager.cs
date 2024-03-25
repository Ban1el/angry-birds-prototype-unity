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

    private void TurnOnUI(string UIName)
    {
        Debug.Log("Here");
        foreach (UIController controller in UserInterfaces)
        {
            if (controller.UIName == UIName)
            {
                controller.gameObject.SetActive(true);
                Debug.Log(controller.UIName);
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
