namespace UI.WindowsLogic
{
    public interface IWindowController
    {
        void Show();
        void Hide();
        void SetUIController(UIController.UIController uiController);
    }
}