using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public string UIName;
    private Button button;
    [SerializeField]
    private string buttonType;
    [SerializeField]
    private string buttonName;

    private void Awake()
    {

        button = GetComponent<Button>();

        if (button != null) 
        {
            button.onClick.AddListener(OnClickButton);
        }
    }

    private void OnClickButton()
    {
        Actions.OnButtonClick?.Invoke(buttonType, buttonName);
    }
}
