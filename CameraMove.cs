using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public float mouseSensitivityX = 200f;
    public float mouseSensitivityY = 200f;
    public float minPitch = -80f;
    public float maxPitch = 80f;
    public float moveSpeed = 5f;
    public Camera playerCamera;

    private float _pitch = 0f;
    private float _yaw = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 euler = transform.eulerAngles;
        _yaw = euler.y;

        if (playerCamera != null)
        {
            _pitch = playerCamera.transform.localEulerAngles.x;
        }
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        if (playerCamera == null)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        _yaw += mouseX;
        transform.rotation = Quaternion.Euler(0f, _yaw, 0f);

        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);

        playerCamera.transform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        moveDirection.y = 0f;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}