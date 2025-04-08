// using script.Dumen_Yonetimi;
// using UnityEngine;
//
// public class WheelCamera : MonoBehaviour
// {
//     public Transform Ship;       
//     public Vector3 offset;       
//     public float rotationSpeed = 5f;
//     public float height = 4f;
//
//     public float zoomSpeed = 2f;      // Zoom hızı
//     public float minZoom = 3f;        // Minimum zoom uzaklığı
//     public float maxZoom = 10f;       // Maksimum zoom uzaklığı
//
//     void Start()
//     {
//         offset = new Vector3(0, height, -6f); 
//     }
//
//     void Update()
//     {
//         FollowShip();
//         HandleZoom();
//
//         if (PlayerInteraction.Instance.IsInWheel)
//         {
//             RotateCamera();
//         }
//     }
//
//     void FollowShip()
//     {
//         transform.position = Ship.position + offset;
//     }
//
//     void RotateCamera()
//     {
//         if (Input.GetMouseButton(1))  
//         {
//             float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
//             transform.RotateAround(Ship.position, Vector3.up, horizontalInput);
//             offset = transform.position - Ship.position;  
//         }
//     }
//
//     void HandleZoom()
//     {
//         float scrollInput = Input.GetAxis("Mouse ScrollWheel");
//
//         // Mesafeyi scroll’a göre değiştir
//         Vector3 direction = offset.normalized;
//         float distance = offset.magnitude - scrollInput * zoomSpeed;
//
//         // Zoom sınırlarını uygula
//         distance = Mathf.Clamp(distance, minZoom, maxZoom);
//
//         offset = direction * distance;
//     }
// }