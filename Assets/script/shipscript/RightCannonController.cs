using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Prefab olarak mermi modeli
    public ParticleSystem ParticlePrefab;

    public Transform cannonMuzzle; // Topun a�z�
    public float fireForce = 2000f; // Ate�leme g�c�
    public float fireCooldown = 3f; // Ate�leme bekleme s�resi
    private float lastFireTime; // Son ate�leme zaman�


    void Update()
    {
        if (Shipmove.instance.isNearSteeringWheel == true)
        {
          
            if (Input.GetMouseButtonDown(1) && Time.time >= lastFireTime + fireCooldown)
            {
                RightFireCannon();
            }
        }
    }

    public void RightFireCannon()
    {
        lastFireTime = Time.time;

        // Mermi olu�tur
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonMuzzle.position, cannonMuzzle.rotation);
        ParticleSystem patlama = Instantiate(ParticlePrefab, cannonMuzzle.position, cannonMuzzle.rotation);

        // Mermiye fiziksel kuvvet uygula
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            patlama.Play();
            rb.AddForce(transform.right * fireForce); // Sol tarafa do�ru kuvvet uygula
        }

        // Mermiyi belirli bir s�re sonra yok et (gereksiz bellek kullan�m�n� �nlemek i�in)
        Destroy(cannonBall, 3f);
        Destroy(patlama.gameObject, 5f);

    }
}
