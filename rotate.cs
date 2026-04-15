using UnityEngine;

public class RotatingRod : MonoBehaviour
{
    [Tooltip("Швидкість обертання в градусах за секунду")]
    public float angularSpeed = 45f;

    [Tooltip("Вісь обертання (наприклад, Vector3.forward або Vector3.up)")]
    public Vector3 rotationAxis = Vector3.forward;

    void Update()
    {
        // Рівномірне обертання навколо локальної осі
        transform.Rotate(rotationAxis.normalized, angularSpeed * Time.deltaTime, Space.Self);
    }
}
