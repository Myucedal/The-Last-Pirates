using System.Collections.Generic;
using UnityEngine;

namespace script.UIscripts

{
    public class UIPanelManager : MonoBehaviour
    {
        public static UIPanelManager instance;
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

        public void OpenPanel(UIPanelBase panel)
        {
            CloseAllPanels();
            panel.Show();
            instance.openPanels.Add(panel);
        }

        public void ClosePanel(UIPanelBase panel)
        {
            panel.Hide();
            instance.openPanels.Remove(panel);
        }

        public void CloseAllPanels()
        {
            foreach (var panel in instance.openPanels)
            {
                panel.Hide();
            }

            instance.openPanels.Clear();
        }


    }
}