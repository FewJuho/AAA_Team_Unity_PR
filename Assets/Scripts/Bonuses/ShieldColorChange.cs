using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material YESMaterial; // ����� �������� ��� ���������
    public Material NOMaterial;
    public Material PICKMaterial; // �������� �������� ������
    private Image buttonImage; // ������ �� ��������� Image


    void Start()
    {
        buttonImage = GetComponent<Image>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        entryEnter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        entryExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
        trigger.triggers.Add(entryExit);
        RestartColors();
    }

    // ���������� ������� ��� ��������� �������
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.material = PICKMaterial;
    }

    // ���������� ������� ��� ������ �������
    public void OnPointerExit(PointerEventData eventData)
    {
        RestartColors();
    }

    public void RestartColors()
    {
        if (DataHolder._shieldsCount == 0)
        {
            buttonImage.material = NOMaterial;
        }
        else
        {
            buttonImage.material = YESMaterial;
        }
    }


}
