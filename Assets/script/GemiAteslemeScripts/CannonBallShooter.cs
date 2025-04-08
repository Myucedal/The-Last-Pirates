using System.Collections;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour
{
    [SerializeField] private CannonBallPoolManager cannonBallPool; 
    [SerializeField] private float ballDestroyDuration = 2f;

    public void FireCannon(Transform cannonTransform, Transform shipTransform, float fireForce, Vector3 direction)
    {
        GameObject ball = cannonBallPool.GetCannonBall(cannonTransform.position);
        ball.transform.SetParent(cannonTransform); 

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero; 
            rb.AddForce(direction * fireForce, ForceMode.Impulse);
        }

        StartCoroutine(ReturnBallAfterTime(ball, ballDestroyDuration));
    }

    private IEnumerator ReturnBallAfterTime(GameObject ball, float time)
    {
        yield return new WaitForSeconds(time);
        cannonBallPool.ReturnCannonBall(ball);
    }
}