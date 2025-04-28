namespace UI.WinodwsLogic
{
    public interface IWindowController
    {
        void Show();
        void Hide();
        void SetUIController(UIController.UIController uiController);
    }
}