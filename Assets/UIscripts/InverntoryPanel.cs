using UnityEngine;

namespace script.UIscripts
{
    public class InverntoryPanel : UIPanelBase
    {
        public void ToggleInventory()
        {
            if (gameObject.activeSelf)
                Hide();
            else
                Show();
        }
    }
}