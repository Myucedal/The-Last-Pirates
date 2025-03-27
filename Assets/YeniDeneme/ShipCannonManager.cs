
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannonManager : MonoBehaviour
{
    [SerializeField] private List<Transform> leftCannons;
    [SerializeField] private List<Transform> rightCannons;

    [SerializeField] private CannonBallShooter leftCannonShooter;
    [SerializeField] private CannonBallShooter rightCannonShooter;
    [SerializeField] private Transform shipTransform;
    

    [SerializeField] float fireForce = 10f;
    [SerializeField] private float fireCooldown = 15f; // 🕒 Ateşleme gecikmesi (1.5 saniye)
    private float leftCoolDown = 0f;
    private float rightCoolDown = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireLeftCannons();
        }

        if (Input.GetMouseButtonDown(1))
        {
            FireRightCannons();
        }
    }

    public void FireLeftCannons()
    {
        if (Time.time < leftCoolDown) 
            return;

        leftCoolDown = Time.time + fireCooldown;
        
        // Debug.Log(leftCoolDown);
        // Debug.Log(Time.time);
        foreach (Transform cannon in leftCannons)
        {
            leftCannonShooter.FireCannon(cannon, shipTransform, fireForce, -shipTransform.right);
        }
    }

  
    public void FireRightCannons()
    {
        if (Time.time < rightCoolDown) 
            return;

        rightCoolDown = Time.time + fireCooldown; 
        // Debug.Log(rightCoolDown);
        // Debug.Log(Time.time);
        foreach (Transform cannon in rightCannons)
        {
            rightCannonShooter.FireCannon(cannon, shipTransform, fireForce, shipTransform.right);        }
    }
}