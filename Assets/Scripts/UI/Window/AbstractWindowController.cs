using Zenject;

namespace UI.Window
{
    public abstract class AbstractWindowController<T> : IInitializable, IWindowController where T : IWindowView
    {
        private T _baseView;
        protected UIController _uiController;

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

        public void SetUIController(UIController uiController)
        {
            _uiController = uiController;
        }

        public void Hide()
        {
            _baseView.Hide();

            OnHide();
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnShow()
        {
        }
    }
}
