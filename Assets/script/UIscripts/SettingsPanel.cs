using UnityEngine;

namespace script.UIscripts
{
    public class SettingsPanel : UIPanelBase
    {
        public void OpenSettings()
        {
            Show();
        }

        public void CloseSettings()
        {
            Hide();
        }
    }
}