using UnityEngine;

public class UIScoreText : MonoBehaviour
{
    [SerializeField]
    GameObject topMostObject;

    public void Destroy()
    {
        Destroy(topMostObject);
    }
}
