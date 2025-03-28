using script.UIscripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipPanel : UIPanelBase, IPointerClickHandler
{
    public TextMeshProUGUI tooltipText;

    public void SetText(string message)
    {
        tooltipText.text = message;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIPanelManager.ClosePanel(this);
    }
}