using UnityEngine;
using UnityEngine.UI;

public class MouseEnter : MonoBehaviour
{
    private Image buttonImage;
    public Color originalColor;
    public Color newColor;
    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    public void OnMouseEnter()
    {
        buttonImage.color = newColor;
    }

    public void OnMouseExit()
    {
        buttonImage.color = originalColor;
    }
}