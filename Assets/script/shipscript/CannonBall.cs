using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public ParticleSystem explosionEffectPrefab; // Patlama efekti prefab'�
    public float destroyDelay = 8f; // Patlama efektini yok etmek i�in gecikme s�resi

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject + "Carpti");
        // �arp��ma an�nda patlama efekti olu�tur
        TriggerExplosion();

        Destroy(gameObject);
    }

    void TriggerExplosion()
    {
        // Patlama efektini olu�tur
        ParticleSystem explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // Belirli bir s�re sonra patlama efektini yok et
        Destroy(explosionEffect.gameObject, destroyDelay);
    }
}