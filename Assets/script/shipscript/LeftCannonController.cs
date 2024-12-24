using UnityEngine;

public class LeftCannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Prefab olarak mermi modeli
    public ParticleSystem ParticlePrefab; // Patlama efekti
    public Transform cannonMuzzle; // Topun aðzý
    public float fireForce = 2000f; // Ateþleme gücü
    public float fireCooldown = 3f; // Ateþleme bekleme süresi

    private float lastFireTime; // Son ateþleme zamaný

    void Update()
    {
        if (Shipmove.instance.isNearSteeringWheel == true)
        {
            // Sol týk yapýldýðýnda ve bekleme süresi dolduðunda mermi fýrlat
            if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + fireCooldown)
            {
                LeftFireCannon();
            }
        }
    }

    public void LeftFireCannon()
    {
        // Son ateþleme zamanýný güncelle
        lastFireTime = Time.time;

        // Mermi oluþtur
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonMuzzle.position, cannonMuzzle.rotation);
        ParticleSystem patlama = Instantiate(ParticlePrefab, cannonMuzzle.position, cannonMuzzle.rotation);

        // Mermiye fiziksel kuvvet uygula
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            patlama.Play();
            rb.AddForce(-transform.right * fireForce); // Sol tarafa doðru kuvvet uygula
        }

        // Mermiyi belirli bir süre sonra yok et
        Destroy(cannonBall, 3f);

        // Patlama efektini belirli bir süre sonra yok et
        Destroy(patlama.gameObject, 5f);
    }
}
