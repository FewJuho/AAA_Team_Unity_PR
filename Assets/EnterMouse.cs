using UnityEngine;
using UnityEngine.UI;

public class EnterMouse : MonoBehaviour
{
    private Image buttonImage;
    private Color originalColor;
    public Color hoverColor = new Color(0.7f, 0.7f, 0.7f, 1f);

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    void OnMouseEnter()
    {
        buttonImage.color = hoverColor;
    }

    void OnMouseExit()
    {
        buttonImage.color = originalColor;
    }
}
