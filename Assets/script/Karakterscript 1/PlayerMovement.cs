using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController; // Karakterin hareketini kontrol eden bileşen
    public Transform cameraTransform;              // Kameranın dönüşünü almak için
    public float speed = 5f;                       // Koşma hızı
    public float jumpHeight = 2f;                  // Zıplama yüksekliği
    public float gravity = -9.81f;                 // Yerçekimi

    private Vector3 velocity;                      // Hız vektörü (zıplama ve yerçekimi)
    private bool isGrounded;                       // Yerde olup olmadığını kontrol eder

    void Update()
    {
        // Yerde olup olmadığını kontrol et
        isGrounded = characterController.isGrounded;

        // Yere temas ediliyorsa, yerçekimi etkisi sıfırlanır
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Hareket et
        MovePlayer();

        // Zıpla
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Zıplama hesaplaması
        }

        // Yerçekimi etkisini uygula
        velocity.y += gravity * Time.deltaTime;

        // Son olarak, hareketi uygula
        characterController.Move(velocity * Time.deltaTime);
    }

    void MovePlayer()
    {
        // Kamera yönüne göre hareket
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Kamera dönüşü ile hareket yönünü hesapla
        Vector3 forward = cameraTransform.forward; // Kameranın ileri yönü
        Vector3 right = cameraTransform.right;     // Kameranın sağ yönü

        // Yalnızca yatay düzlemdeki yönleri al, yukarı ve aşağı hareket etmeyi engelle
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Hareket yönü
        Vector3 direction = forward * vertical + right * horizontal;

        // Hareketi uygula
        characterController.Move(direction * speed * Time.deltaTime);
    }
}
