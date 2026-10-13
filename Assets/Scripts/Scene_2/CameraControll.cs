using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The player or object to orbit around
    public float distance = 2.0f; // Default distance from target

    [Header("Rotation Settings")]
    public float mouseSensitivity = 3.0f; // Mouse sensitivity
    public float minYAngle = -35f; // Minimum vertical angle
    public float maxYAngle = 60f;  // Maximum vertical angle
    public bool invertY = false;   // Invert vertical mouse movement

    [Header("Smoothness")]
    public float smoothTime = 0.1f; // Smoothing factor

    private float currentX = 0f;
    private float currentY = 20f;
    private float smoothX, smoothY;
    private float velocityX, velocityY;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraOrbit: No target assigned!");
            enabled = false;
            return;
        }

        // Lock and hide cursor for better control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * (invertY ? 1 : -1);

        // Update rotation values
        currentX += mouseX;
        currentY += mouseY;

        // Clamp vertical rotation
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        // Smooth rotation
        smoothX = Mathf.SmoothDamp(smoothX, currentX, ref velocityX, smoothTime);
        smoothY = Mathf.SmoothDamp(smoothY, currentY, ref velocityY, smoothTime);

        // Calculate rotation and position
        Quaternion rotation = Quaternion.Euler(smoothY, smoothX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        Vector3 position = target.position + rotation * direction;

        // Apply to camera
        transform.rotation = rotation;
        transform.position = position;
    }
}
