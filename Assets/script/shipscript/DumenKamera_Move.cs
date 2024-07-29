using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumenKamera_Move : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    private float xRotation = 0, yRotation = 0;
    public float zoomSpeed = 10f;
    float zoomOlcu;
    public Camera cam;

    void Update()
    {
        zoomOlcu = cam.fieldOfView;
        zoomOlcu -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomOlcu = Mathf.Clamp(zoomOlcu, 20, 100);
        cam.fieldOfView = zoomOlcu;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY * 5;
        xRotation = Mathf.Clamp(xRotation, -47f, 45);
        yRotation += mouseX * 5;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
