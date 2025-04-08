using System;
using UnityEngine;

namespace script.Dumen_Yonetimi
{
    public class PlayerInteraction : MonoBehaviour
    {
        private IControllable currentControllable;
        public GameObject Wheel;
        public bool IsInWheel { get; set; } = false;
        public bool IsInWheelSide { get; set; } = false;
        public static PlayerInteraction Instance;

        private void Awake()
        {
            Instance = this;
            if (currentControllable == null)
            {
                Debug.Log("No IControllable");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var controllable = other.GetComponentInParent<IControllable>();
            if (controllable != null)
            {
                currentControllable = controllable;
                IsInWheelSide = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponentInParent<IControllable>() == currentControllable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!IsInWheel)
                    {
                        currentControllable.OnControlStart(gameObject);
                        CameraController.Instance.FocusOnShip();
                    }
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (IsInWheel)
                    {
                        currentControllable.OnControlEnd();
                        currentControllable = null;
                        CameraController.Instance.FocusOnPlayer();
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInParent<IControllable>() == currentControllable)
            {
                IsInWheelSide = false;
                currentControllable = null;
            }
        }
    }
}