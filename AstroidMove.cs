using UnityEngine;

public class AstroidMotion : MonoBehaviour
{
    [Tooltip("Розмір астроїди (a у формулах)")]
    public float a = 3f;

    [Tooltip("Швидкість обходу по кривій (рад/с)")]
    public float angularSpeed = 1f;

    [Tooltip("Центр астроїди в світових координатах")]
    public Vector3 center = Vector3.zero;

    [Tooltip("Фіксована висота руху (Y)")]
    public float height = 0.5f;

    private float _t; // параметр t у радіанах

    void Update()
    {
        _t += angularSpeed * Time.deltaTime;

        float cosT = Mathf.Cos(_t);
        float sinT = Mathf.Sin(_t);

        // x = a cos^3 t, z = a sin^3 t (астроїда в площині XZ)
        float x = center.x + a * cosT * cosT * cosT;
        float z = center.z + a * sinT * sinT * sinT;
        float y = center.y + height;

        Vector3 newPos = new Vector3(x, y, z);
        transform.position = newPos;

        // (необов'язково) орієнтуємо циліндр по дотичній до траєкторії
        float dt = 0.01f;
        float tAhead = _t + dt;
        float cosTA = Mathf.Cos(tAhead);
        float sinTA = Mathf.Sin(tAhead);

        float xAhead = center.x + a * cosTA * cosTA * cosTA;
        float zAhead = center.z + a * sinTA * sinTA * sinTA;
        Vector3 aheadPos = new Vector3(xAhead, y, zAhead);

        Vector3 direction = (aheadPos - newPos).normalized;
        if (direction.sqrMagnitude > 0.0001f)
        {
            // Циліндр «дивиться» уздовж траєкторії (вісь forward)
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}