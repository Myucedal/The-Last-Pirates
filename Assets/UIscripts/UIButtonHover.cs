using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHover : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject tooltipPrefab;
    [SerializeField] private Transform canvasTransform;

    private float tooltipOffset = 30f; // Tooltip'in konumunu ayarlamak için
    private GameObject currentTooltip;
    private RectTransform tooltipRectTransform;
    private RectTransform buttonRectTransform;  

    private string tooltipMessage = "bombastik side eye";
    private bool tooltipActive = false; // Tooltip aktif mi?

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
    }

    // Butona tıklanırsa tooltip açılacak ve kapanacak
    public void OnPointerClick(PointerEventData eventData)
    {
        if (tooltipActive)
        {
            ClosePanel(); // Eğer aktifse, kapat
        }
        else
        {
            ShowTooltip(eventData); // Değilse, göster
        }
    }

    // Tooltip'i göster
    private void ShowTooltip(PointerEventData eventData)
    {
        currentTooltip = Instantiate(tooltipPrefab, canvasTransform);
        tooltipRectTransform = currentTooltip.GetComponent<RectTransform>();

        TooltipPanel tooltipScript = currentTooltip.GetComponent<TooltipPanel>();
        // tooltipScript.SetParentButton(this);
        tooltipScript.SetText(tooltipMessage);

        PositionTooltip(eventData);
        tooltipActive = true;
    }

    // Tooltip'i kapat
    public void ClosePanel()
    {
        Destroy(currentTooltip);
        tooltipActive = false;
    }

    // Tooltip'in doğru konumda görünmesini sağla
    private void PositionTooltip(PointerEventData eventData)
    {
        Vector2 buttonScreenPos = RectTransformUtility.WorldToScreenPoint(
            eventData.pressEventCamera, buttonRectTransform.position);
        Vector2 tooltipSize = tooltipRectTransform.sizeDelta;

        // Sağ tarafa yakınsa solunda, üst tarafa yakınsa altında göstermek için
        float tooltipX = buttonScreenPos.x + tooltipOffset;
        float tooltipY = buttonScreenPos.y + tooltipOffset;

        if (tooltipX + tooltipSize.x /2  > Screen.width)
        {
            tooltipX = buttonScreenPos.x - tooltipSize.x /2 - tooltipOffset;
        }
        
        if (tooltipY + tooltipSize.y /2  > Screen.height)
        {
            tooltipY = buttonScreenPos.y - tooltipSize.y/2 - tooltipOffset;
        }

        tooltipRectTransform.position = new Vector2(tooltipX, tooltipY);
    }
}
