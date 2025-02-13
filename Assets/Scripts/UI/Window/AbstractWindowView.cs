using UnityEngine;

namespace UI.Window
{
    public abstract class AbstractWindowView : MonoBehaviour, IWindowView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        protected virtual void OnShow()
        {
            
        }
    }
}