using System.Collections;
using System.Collections.Generic;
using script.Dumen_Yonetimi;
using UnityEngine;

public class ShipCannonManager : MonoBehaviour
{
    [SerializeField] private List<Transform> leftCannons;
    [SerializeField] private List<Transform> rightCannons;

    [SerializeField] private CannonBallShooter leftCannonShooter;
    [SerializeField] private CannonBallShooter rightCannonShooter;
    [SerializeField] private Transform shipTransform;


    [SerializeField] float fireForce = 10f;
    [SerializeField] private float fireCooldown = 5f;
    private float leftCoolDown = 0f;
    private float rightCoolDown = 0f;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerInteraction.Instance.IsInWheel)
            {
                FireLeftCannons();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (PlayerInteraction.Instance.IsInWheel)
            {
                FireRightCannons();
            }
        }
    }

    public void FireLeftCannons()
    {
        if (Time.time < leftCoolDown)
            return;

        leftCoolDown = Time.time + fireCooldown;
        
        foreach (Transform cannon in leftCannons)
        {
            leftCannonShooter.FireCannon(cannon, shipTransform, fireForce, -shipTransform.right);
            ParticleManager.Instance.Play("TopAtesle", cannon.position, Quaternion.identity, 4f);
        }
    }


    public void FireRightCannons()
    {
        if (Time.time < rightCoolDown)
            return;

        rightCoolDown = Time.time + fireCooldown;
        
        foreach (Transform cannon in rightCannons)
        {
            rightCannonShooter.FireCannon(cannon, shipTransform, fireForce, shipTransform.right);
            ParticleManager.Instance.Play("TopAtesle", cannon.position, Quaternion.identity, 4f);
        }
    }
}