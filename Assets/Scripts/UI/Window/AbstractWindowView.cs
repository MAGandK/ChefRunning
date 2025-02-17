using UnityEngine;

namespace UI.Window
{
    public abstract class AbstractWindowView : MonoBehaviour, IWindowView
    {
        public void Show()
        {
            gameObject.SetActive(true);

            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            OnHide();
        }

        protected virtual void OnShow()
        {

        }

        protected virtual void OnHide()
        {

        }
    }
}
