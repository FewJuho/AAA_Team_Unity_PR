using UnityEngine;

public class ElementToggle : MonoBehaviour
{
    public GameObject element;
    public KeyCode toggleKey = KeyCode.Tab;

    void Update()
    {
        // ���������, ���� �� ������ ������� Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ����������� ��������� ���������� ��������
            element.SetActive(!element.activeSelf);
        }
    }
}