using UnityEngine;

public class mausemovepirates : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    public Transform playerBody, cameraPivot;
    private float xRotation = 0.0f, yRotation = 0;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY*5;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        yRotation += mouseX*5;

        // Kamera yaln�zca yukar� ve a�a�� hareket edecek
        transform.localRotation = Quaternion.Euler(0, yRotation, 0f);
        cameraPivot.transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);

        // Karakter yaln�zca sa�a ve sola d�necek
        playerBody.Rotate(Vector3.up * mouseY);
    }
}