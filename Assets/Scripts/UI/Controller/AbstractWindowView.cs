using UnityEngine;

namespace UI
{
    public abstract class AbstractWindowView : MonoBehaviour, IWindowView
    {
        [SerializeField] private Renderer _renderer;
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

        public void SetOrderInLayer(int order)
        {
            _renderer.sortingOrder = order;
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}