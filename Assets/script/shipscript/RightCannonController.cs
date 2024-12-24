using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab; // Prefab olarak mermi modeli
    public ParticleSystem ParticlePrefab;

    public Transform cannonMuzzle; // Topun aðzý
    public float fireForce = 2000f; // Ateþleme gücü
    public float fireCooldown = 3f; // Ateþleme bekleme süresi
    private float lastFireTime; // Son ateþleme zamaný


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

        // Mermi oluþtur
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonMuzzle.position, cannonMuzzle.rotation);
        ParticleSystem patlama = Instantiate(ParticlePrefab, cannonMuzzle.position, cannonMuzzle.rotation);

        // Mermiye fiziksel kuvvet uygula
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            patlama.Play();
            rb.AddForce(transform.right * fireForce); // Sol tarafa doðru kuvvet uygula
        }

        // Mermiyi belirli bir süre sonra yok et (gereksiz bellek kullanýmýný önlemek için)
        Destroy(cannonBall, 3f);
        Destroy(patlama.gameObject, 5f);

    }
}
