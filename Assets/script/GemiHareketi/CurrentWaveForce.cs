using UnityEngine;

namespace script.GemiHareketi
{
    public class CurrentWaveForce
    {
        public Vector3 currentDirection = Vector3.forward;
        public float strength = 5f;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Ship"))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(currentDirection.normalized * strength);
                }
            }
        }
    }
}