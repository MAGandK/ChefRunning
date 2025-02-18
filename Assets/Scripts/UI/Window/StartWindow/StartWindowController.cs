using UI.Window.GameWindow;

namespace UI.Window.StartWindow
{
    public class StartWindowController : AbstractWindowController<StartWindowView>
    {
        private readonly StartWindowView _view;

        public StartWindowController(StartWindowView view) : base(view)
        {
            _view = view;
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.SubscribeButton(OnStartButtonClick);
        }

        protected override void OnShow()
        {
            base.OnShow();
            _view.SetupProgressBar();
        }

        private void OnStartButtonClick()
        {
            _uiController.ShowWindow<GameWindowController>();
        }
    }
}