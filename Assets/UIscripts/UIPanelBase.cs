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
        }    
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
}