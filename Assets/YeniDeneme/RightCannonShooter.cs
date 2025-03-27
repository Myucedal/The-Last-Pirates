// using System.Collections;
// using UnityEngine;
//
// [CreateAssetMenu(fileName = "LeftCannonShooter", menuName = "Sc/CannonShooter/Left")]
// public class RightCannonShooter : CannonBallShooter
// {
//     public override void FireCannon(Transform cannonTransform, Transform shipTransform, float fireForce)
//     {
//         Debug.Log("Firing Left Cannon");
//
//         GameObject ball = GetCannonBall(cannonTransform.position);
//         Rigidbody rb = ball.GetComponent<Rigidbody>();
//
//         if (rb != null)
//         {
//             rb.velocity = Vector3.zero;
//             rb.AddForce(shipTransform.right * fireForce, ForceMode.Impulse);
//         }
//
//         // Coroutine'i başlatmak için ShipCannonManager kullanıyoruz
//         ShipCannonManager.Instance.StartCoroutine(ReturnBallAfterTime(ball, ballDestroyDuration));
//     }
//
//     private IEnumerator ReturnBallAfterTime(GameObject ball, float time)
//     {
//         yield return new WaitForSeconds(time);
//         ReturnCannonBall(ball);
//     }
// }