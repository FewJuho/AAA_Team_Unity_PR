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
        // ���������, ���� �� ������ ������� Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ����������� ��������� ���������� ��������
            element.SetActive(!element.activeSelf);
        }
    }
}