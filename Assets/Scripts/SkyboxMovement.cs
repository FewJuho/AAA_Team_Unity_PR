using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    public float rotationSpeed = 5f; // Скорость вращения Skybox

    void Update()
    {
        RotateSkybox();
    }

    void RotateSkybox()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}