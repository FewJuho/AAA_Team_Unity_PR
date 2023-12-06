using UnityEngine;

public class ElementToggle : MonoBehaviour
{
    public GameObject element;
    public KeyCode toggleKey = KeyCode.Tab;

    private void Start()
    {
        element.SetActive(false);
    }
    void Update()
    {
        // Проверяем, была ли нажата клавиша Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Инвертируем состояние активности элемента
            element.SetActive(!element.activeSelf);
        }
    }
}