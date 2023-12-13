using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeMaterialOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material hoverMaterial; // Новый материал при наведении

    private Material originalMaterial; // Исходный материал кнопки
    private Image buttonImage; // Ссылка на компонент Image

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalMaterial = buttonImage.material;

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        entryEnter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        entryExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
        trigger.triggers.Add(entryExit);
    }

    // Обработчик события при наведении курсора
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.material = hoverMaterial;
    }

    // Обработчик события при выходе курсора
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.material = originalMaterial;
    }

    public void RestartColors()
    {
        buttonImage.material = originalMaterial;
    }
}
