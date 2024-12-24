using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public ParticleSystem explosionEffectPrefab; // Patlama efekti prefab'ý
    public float destroyDelay = 8f; // Patlama efektini yok etmek için gecikme süresi

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject + "Carpti");
        // Çarpýþma anýnda patlama efekti oluþtur
        TriggerExplosion();

        Destroy(gameObject);
    }

    void TriggerExplosion()
    {
        // Patlama efektini oluþtur
        ParticleSystem explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // Belirli bir süre sonra patlama efektini yok et
        Destroy(explosionEffect.gameObject, destroyDelay);
    }
}