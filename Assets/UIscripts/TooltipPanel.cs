using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipPanel : MonoBehaviour, IPointerClickHandler
{
    public UIButtonHover uıButtonHover;

    private void Start()
    {
        if (uıButtonHover == null)
        {
            uıButtonHover = gameObject.GetComponent<UIButtonHover>();
        }
    }

    // Tooltip içindeki yazıyı değiştir
    public void SetText(string message)
    {
        TextMeshProUGUI tooltipText = GetComponentInChildren<TextMeshProUGUI>(); // Tooltip'teki yazıyı bul
        tooltipText.text = message; // Mesajı ata
    }
    


    // Buton ile ilişkilendir
    public void SetParentButton(UIButtonHover button)
    {
        uıButtonHover = button;
    }

    // Tooltip'e tıklandığında kapatma işlemi
    public void OnPointerClick(PointerEventData eventData)
    {
        // Tooltip'e tıklanırsa, butonun tooltip'i kapatması sağlanır
        uıButtonHover.ClosePanel();
    }
}