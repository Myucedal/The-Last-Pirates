using UnityEngine;
using UnityEngine.EventSystems;

namespace script.Dumen_Yonetimi
{
    public class ShipController : MonoBehaviour, IControllable
    {
        public Transform helmTransform; // Dümen pozisyon
        public Camera shipCamera;
        private GameObject currentController;
        private PlayerMovement playerMovement;

        public void OnControlStart(GameObject controller)
        {
            currentController = controller;
            playerMovement = controller.GetComponent<PlayerMovement>();

            controller.transform.position = helmTransform.position;
            controller.transform.rotation = helmTransform.rotation;

            playerMovement.enabled = false;

            
            if (shipCamera != null)
            {
                shipCamera.enabled = true;
            }

            PlayerInteraction.Instance.IsInWheel = true;

            Debug.Log("Gemi kontrol ediliyor.");
        }

        public void OnControlEnd()
        {
            if (currentController != null)
            {
                playerMovement.enabled = true;


                if (shipCamera != null)
                {
                    shipCamera.enabled = false;
                }

                PlayerInteraction.Instance.IsInWheel = false;
                currentController = null;

                Debug.Log("Gemi kontrolü sona erdi.");
            }
        }

        public Transform GetControlPoint()
        {
            return helmTransform;
        }
    }
}