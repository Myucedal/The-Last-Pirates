using System.Collections.Generic;
using UnityEngine;

namespace script.UIscripts

{
    public class UIPanelManager : MonoBehaviour
    {
        private static UIPanelManager instance;
        private List<UIPanelBase> openPanels = new List<UIPanelBase>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void OpenPanel(UIPanelBase panel)
        {
            instance.CloseAllPanels();
            panel.Show();
            instance.openPanels.Add(panel);
        }

        public static void ClosePanel(UIPanelBase panel)
        {
            panel.Hide();
            instance.openPanels.Remove(panel);
        }

        public static void CloseAllPanels()
        {
            foreach (var panel in instance.openPanels)
            {
                panel.Hide();
            }

            instance.openPanels.Clear();
        }
    }
}