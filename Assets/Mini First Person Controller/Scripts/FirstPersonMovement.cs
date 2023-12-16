using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10f; // Новая переменная для силы прыжка.

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Получаем Rigidbody у этого объекта.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Обновляем IsRunning в зависимости от ввода.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Получаем targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Получаем targetVelocity из ввода.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Применяем горизонтальное движение.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        // Добавляем возможность летать при длительном нажатии на Space.
        if (Input.GetKey(KeyCode.Space) && DataHolder.jatpackActivated)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
        }
    }
}
