using System;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("DontExplosion"))
        {
            CannonBallPoolManager.Instance.ReturnCannonBall(this.gameObject);
            ParticleManager.Instance.Play("TopPatlamasi", this.transform.position, Quaternion.identity, 4f);
            
        }
    }
}