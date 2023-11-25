using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float _speed = 5.0f;

    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(deltaX, 0, deltaZ);
    }
}
