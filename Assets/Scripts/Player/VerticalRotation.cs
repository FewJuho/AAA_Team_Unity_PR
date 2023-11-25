// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class VerticalRotation : MonoBehaviour
// {
//     public float _mouse_sensetivity = 50.0f;

//     private float _rotationX = 0.0f;

//     public float _minVerticalRotation = -10.0f;
//     public float _maxVerticalRotation = 10.0f;


//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         _rotationX -= Input.GetAxis("Mouse Y") * _mouse_sensetivity; // * Time.deltaTime;
//         _rotationX = Mathf.Clamp(_rotationX, _minVerticalRotation, _maxVerticalRotation);
        
//         float rotationY = transform.localEulerAngles.y;
//         transform.localEulerAngles = new Vector3(_rotationX, rotationY);
//         // transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
//         // transform.Rotate(yaw, 0, 0);

//         // transform.Rotate(yaw, 0, 0);


//         // transform.localEulerAngles += new Vector3(0.1f, 0.1f, 0.1f);
//     }
// }
