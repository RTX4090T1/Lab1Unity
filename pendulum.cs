using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Tooltip("Максимальне відхилення маятника від вертикалі (в градусах)")]
    public float maxAngle = 80f;

    [Tooltip("Частота коливань (кількість повних коливань за секунду)")]
    public float frequency = 2f;

    private float _time;

    void Update()
    {
        _time += Time.deltaTime;

        // Кутова позиція маятника як гармонічне коливання
        float angle = maxAngle * Mathf.Sin(2f * Mathf.PI * frequency * _time);

        // Обертання навколо локальної осі Z (як приклад)
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}