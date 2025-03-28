using UnityEngine;
using UnityEngine.EventSystems;

namespace script.UIscripts

{
    public class UIButtonHover : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TooltipPanel tooltipPrefab;
        [SerializeField] private Transform canvasTransform;

        private TooltipPanel currentTooltip;
        private bool tooltipActive = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (tooltipActive)
            {
                UIPanelManager.ClosePanel(currentTooltip);
                tooltipActive = false;
            }
            else
            {
                OpenTooltip(eventData);
            }
        }

        private void OpenTooltip(PointerEventData eventData)
        {
            TooltipPanel newTooltip = Instantiate(tooltipPrefab, canvasTransform);
            newTooltip.SetText("bombastik side eye");

            UIPanelManager.OpenPanel(newTooltip);
            currentTooltip = newTooltip;
            tooltipActive = true;
        }
    }
}