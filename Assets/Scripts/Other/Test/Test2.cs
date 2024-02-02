using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    public Image img;

    private void Awake()
    {
        img = GetComponent<Image>();

        Color color;
        color = img.color;
        color.a = 0.5f;
        img.color = color;
    }
}
