using script.UIscripts;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    public static UIPanelManager Instance { get; private set; }

    private UIPanelBase activePanel; // Şu an açık olan panel

    private void Awake()
    {   
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetActivePanel(UIPanelBase panel)
    {
        if (activePanel != null && activePanel != panel)
        {
            activePanel.Hide(); // Önceki paneli kapat
        }
        activePanel = panel;
    }

    public void CloseCurrentPanel()
    {
        if (activePanel != null)
        {
            activePanel.Hide();
            activePanel = null;
        }
    }
}