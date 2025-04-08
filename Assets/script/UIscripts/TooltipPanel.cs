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
        TextMeshProUGUI tooltipText = GetComponentInChildren<TextMeshProUGUI>(); 
        tooltipText.text = message; 
    }
    


    // Buton ile ilişkilendir
    public void SetParentButton(UIButtonHover button)
    {
        uıButtonHover = button;
    }

    // Tooltip'e tıklandığında kapatma işlemi
    public void OnPointerClick(PointerEventData eventData)
    {
        uıButtonHover.ClosePanel();
    }
}