using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject buttonClick;
    private void OnMouseDown()
    {
        Debug.Log("Object Clicked!");
    }
}
