using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour
{
    public float _mouse_sensetivity = 250.0f;

    void Update()
    {
        float pitch = Input.GetAxis("Mouse X") * _mouse_sensetivity * Time.deltaTime;
        transform.Rotate(0, pitch, 0);
    }
}
