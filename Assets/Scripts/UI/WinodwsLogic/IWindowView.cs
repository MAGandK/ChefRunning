namespace UI.WinodwsLogic
{
    public interface IWindowView
    {
        void Show();
        void Hide();
        
        void SetOrderInLayer(int order);
    }
}