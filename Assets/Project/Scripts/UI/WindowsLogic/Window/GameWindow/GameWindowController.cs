namespace UI.WindowsLogic.Window.GameWindow
{
    public class GameWindowController : AbstractWindowController<GameWindowView>
    {
        private GameWindowView _gameWindowView;

        public GameWindowController(GameWindowView view) : base(view)
        {
            _gameWindowView = view;
        }
    }
}