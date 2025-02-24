using UnityEngine;

namespace UI.Window
{
    public abstract class WindowBase : MonoBehaviour
    {
        public bool IsActive
        {
            get { return gameObject.activeSelf; }
        }
        
        public virtual void ShowWindow()
        {
            gameObject.SetActive(true);
        }

        public virtual void CloseWindow()
        {
            gameObject.SetActive(false);
        }
    }
}