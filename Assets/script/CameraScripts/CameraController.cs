using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform ship;
    public float rotationSpeed = 5f;
    public float zoomSpeed = 3f;
    public float minZoom = 5f;
    public float maxZoom = 50f;

    private Transform currentTarget;
    private float distance = 10f;

    private float yaw; // Yatay açı
    private float pitch; // Dikey açı

    private float minPitch = -7.5f;
    private float maxPitch = 60f;

    private bool isRotating = false;

    public static CameraController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTarget = player;
        Vector3 offset = transform.position - currentTarget.position;
        distance = offset.magnitude;

        FocusOnPlayer();
    }

    void Update()
    {
        HandleZoom();
        HandleRotation();
        UpdateCameraPosition();
    }

    void HandleRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed;

            yaw += mouseX;
            pitch += mouseY;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoom, maxZoom);
    }

    void UpdateCameraPosition()
    {
        if (currentTarget == null) return;

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredDirection = rotation * Vector3.back;
        Vector3 desiredPosition = currentTarget.position + desiredDirection * distance;

        Vector3 finalPosition = desiredPosition;

        // Engel kontrolü
        RaycastHit hit;
        Debug.DrawRay(currentTarget.position, desiredDirection, Color.red);
        if (Physics.Raycast(currentTarget.position, desiredDirection, out hit, distance))
        {
            // Tag'e göre yok sayılacak objeler kontrolü (isteğe bağlı)
            if (!hit.collider.CompareTag("IgnoreCameraRay"))
            {
                
                float adjustedDistance = hit.distance - 0.3f; // Tam yapışmasın
                adjustedDistance = Mathf.Clamp(adjustedDistance, 2f, distance); // Min mesafeyi sabit tut

                finalPosition = currentTarget.position + desiredDirection * adjustedDistance;
            }
        }

        // Kamera pozisyonunu yumuşak geçişle ayarla
        transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * 10f);

        // Hedefe bak
        transform.LookAt(currentTarget);
    }

    public void FocusOnShip()
    {
        currentTarget = ship;
        distance = 30f;
        pitch = 20f;
        yaw = 0f;
        minPitch = -7.5f;
        maxPitch = 60f;
    }

    public void FocusOnPlayer()
    {
        currentTarget = player;
        distance = 6f;
        pitch = 20f;
        yaw = 0f;
        minPitch = 5f;
        maxPitch = 60f;
    }
}