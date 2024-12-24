using UnityEngine;

public class LeftCannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Prefab olarak mermi modeli
    public ParticleSystem ParticlePrefab; // Patlama efekti
    public Transform cannonMuzzle; // Topun a�z�
    public float fireForce = 2000f; // Ate�leme g�c�
    public float fireCooldown = 3f; // Ate�leme bekleme s�resi

    private float lastFireTime; // Son ate�leme zaman�

    void Update()
    {
        if (Shipmove.instance.isNearSteeringWheel == true)
        {
            // Sol t�k yap�ld���nda ve bekleme s�resi doldu�unda mermi f�rlat
            if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + fireCooldown)
            {
                LeftFireCannon();
            }
        }
    }

    public void LeftFireCannon()
    {
        // Son ate�leme zaman�n� g�ncelle
        lastFireTime = Time.time;

        // Mermi olu�tur
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonMuzzle.position, cannonMuzzle.rotation);
        ParticleSystem patlama = Instantiate(ParticlePrefab, cannonMuzzle.position, cannonMuzzle.rotation);

        // Mermiye fiziksel kuvvet uygula
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            patlama.Play();
            rb.AddForce(-transform.right * fireForce); // Sol tarafa do�ru kuvvet uygula
        }

        // Mermiyi belirli bir s�re sonra yok et
        Destroy(cannonBall, 3f);

        // Patlama efektini belirli bir s�re sonra yok et
        Destroy(patlama.gameObject, 5f);
    }
}
