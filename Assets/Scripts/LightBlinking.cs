using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    public float minIntensity = 0f;
    public float maxIntensity = 0.5f;
    public float minDelay = 0.1f;       // Минимальная задержка перед следующим мерцанием
    public float maxDelay = 2.0f;       // Максимальная задержка перед следующим мерцанием

    private Light gameLight;
    private float nextBlinkTime;

    void Start()
    {
        gameLight = GetComponent<Light>();
        if (gameLight == null)
        {
            Debug.LogError("Компонент Light не найден на объекте.");
        }

        // Установка первой задержки перед мерцанием
        nextBlinkTime = Time.time + Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        // Проверка, прошло ли достаточно времени для следующего мерцания
        if (Time.time >= nextBlinkTime)
        {
            // Изменение интенсивности света
            float targetIntensity = Random.Range(0.0f, 1.0f);
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, targetIntensity);
            gameLight.intensity = intensity;

            // Установка следующей задержки перед мерцанием
            nextBlinkTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
