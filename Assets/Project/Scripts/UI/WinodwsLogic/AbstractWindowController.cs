using Zenject;

namespace UI.WinodwsLogic
{
    public abstract class AbstractWindowController<T> : IInitializable, IWindowController where T : IWindowView
    {
        private T _baseView;
        protected UIController.UIController _uiController;

        protected AbstractWindowController(T view)
        {
            _baseView = view;
        }

        public virtual void Initialize()
        {
        }

        public void Show()
        {
            _baseView.Show();
            OnShow();
        }

        public void Hide()
        {
            _baseView.Hide();
            OnHide();
        }

        public void SetUIController(UIController.UIController uiController)
        {
            _uiController = uiController;
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}