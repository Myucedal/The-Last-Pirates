// using System.Collections;
// using UnityEngine;
//
// public class LeftCannonShooter : MonoBehaviour
// {
//     CannonBallPoolManager objectPooler;
//
//     private void Start()
//     {
//         objectPooler = CannonBallPoolManager.Instance;
//     }
//
//     public void Fire()
//     {
//         CannonBallPoolManager.Instance.SpawnFromPool("Left ball" , transform.position, Quaternion.identity);
//     }
// }