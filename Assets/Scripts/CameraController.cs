using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float sensitivity;

    private float xRotation;
    private float yRotation;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -89.9f, 89.9f);

        target.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
