using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHover : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject tooltipPrefab;
    [SerializeField] private Transform canvasTransform;

    private float tooltipOffset = 30f;
    private GameObject currentTooltip;
    private RectTransform tooltipRectTransform;
    private RectTransform buttonRectTransform;

    private string tooltipMessage = "bombastik side eye";
    private bool tooltipActive = false;

    // **Açık olan tooltipleri takip eden liste**
    private static List<GameObject> openTooltips = new List<GameObject>();

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tooltipActive)
        {
            ClosePanel();
        }
        else
        {
            CloseAllTooltips(); // Önce tüm açık tooltipleri kapat
            ShowTooltip(eventData);
        }
    }

    private void ShowTooltip(PointerEventData eventData)
    {
        if (currentTooltip != null)
        {
            Destroy(currentTooltip);
            tooltipActive = false;
        }

        currentTooltip = Instantiate(tooltipPrefab, canvasTransform);
        tooltipRectTransform = currentTooltip.GetComponent<RectTransform>();

        TooltipPanel tooltipScript = currentTooltip.GetComponent<TooltipPanel>();
        tooltipScript.SetParentButton(this);
        tooltipScript.SetText(tooltipMessage);

        PositionTooltip(eventData);
        tooltipActive = true;

        // **Yeni tooltipi listeye ekle**
        openTooltips.Add(currentTooltip);
    }

    public void ClosePanel()
    {
        if (currentTooltip != null)
        {
            openTooltips.Remove(currentTooltip); // Liste içinden çıkar
            Destroy(currentTooltip);
            tooltipActive = false;
        }
    }

    // **Tüm açık tooltipleri kapat**
    private void CloseAllTooltips()
    {
        foreach (var tooltip in openTooltips)
        {
            if (tooltip != null)
            {
                Destroy(tooltip);
            }
        }
        openTooltips.Clear(); // Listeyi temizle
    }

    private void PositionTooltip(PointerEventData eventData)
    {
        Vector2 buttonScreenPos = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, buttonRectTransform.position);
        Vector2 tooltipSize = tooltipRectTransform.sizeDelta;

        float tooltipX = buttonScreenPos.x + tooltipOffset;
        float tooltipY = buttonScreenPos.y + tooltipOffset;

        if (tooltipX + tooltipSize.x / 2 > Screen.width)
        {
            tooltipX = buttonScreenPos.x - tooltipSize.x / 5 - tooltipOffset;
        }

        if (tooltipY + tooltipSize.y / 2 > Screen.height)
        {
            tooltipY = buttonScreenPos.y - tooltipSize.y / 5 - tooltipOffset;
        }

        tooltipRectTransform.position = new Vector2(tooltipX, tooltipY);
    }
}
