using Zenject;

namespace UI.Window.StartWindow
{
    public abstract class AbstractWindowController<T> : IInitializable, IWindowController where T : IWindowView
    {
        private  T _baseView;
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
            OnShow();
        }

        public void SetUIController(UIController uiController)
        {
            _uiController = uiController;
        }

        protected virtual void OnShow()
        {
            
        }
    }
}