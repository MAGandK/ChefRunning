using UI.Window;
using UI.Window.StartWindow;

namespace UI
{
    public interface IUIController
    {
        void ShowWindow<T>() where T : IWindowController;
        T GetWindow<T>() where T : class, IWindowController;
    }
}