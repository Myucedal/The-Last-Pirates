using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Oyuncu objesi
    public Vector3 offset;        // Kameranın oyuncuya olan mesafesi
    public float rotationSpeed = 5f;  // Kameranın dönüş hızı
    public float height = 4f;     // Kameranın yüksekliği (yukarı-aşağı)

    void Start()
    {
        offset = new Vector3(0, height, -6f); // Hafif üstten ve arkadan bakacak
    }

    void Update()
    {
        // Kamera oyuncuyu takip etsin
        FollowPlayer();

        // Kamera oyuncunun etrafında dönsün
        RotateCamera();
    }

    void FollowPlayer()
    {
        transform.position = player.position + offset;
    }

    void RotateCamera()
    {
        // Sağ fare tuşu ile kamerayı döndürme
        if (Input.GetMouseButton(1))  // Sağ fare tuşuna basılı tutmak
        {
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.RotateAround(player.position, Vector3.up, horizontalInput);
            offset = transform.position - player.position;  // Offset güncellenir
        }
    }
}