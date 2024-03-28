using UnityEngine;
using TMPro;

public class UITextController : MonoBehaviour
{
    [SerializeField]
    private string UIName;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void SetText(string _text, string _UIName)
    {
        if (UIName == _UIName)
        {
            text.SetText(_text);
        }
    }

    private void OnEnable()
    {
        Actions.OnSetUIText += SetText;
    }

    private void OnDisable()
    {
        Actions.OnSetUIText -= SetText;
    }
}
