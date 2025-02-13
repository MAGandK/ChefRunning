namespace UI.Window.MainWindow
{
    public class MainWindowController : AbstractWindowController<MainWindowView>
    {
        private MainWindowView _mainWindowView;

        public MainWindowController(MainWindowView view) : base(view)
        {
            _mainWindowView = view;
        }
    }
}