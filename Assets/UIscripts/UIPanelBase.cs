using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace script.UIscripts
{
    public abstract class UIPanelBase : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
            UIPanelManager.Instance.SetActivePanel(this); 
        }    
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
}