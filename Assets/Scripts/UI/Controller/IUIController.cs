namespace UI
{
    public interface IUIController
    {
        void ShowWindow<T>() where T : IWindowController;

        T GetWindow<T>() where T : class,IWindowController;

        void CloseLastOpenPopup();
    }
}