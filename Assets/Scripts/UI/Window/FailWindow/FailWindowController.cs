namespace UI.Window.FailWindow
{
    public class FailWindowController : AbstractWindowController<FailWindowView>
    {
        private readonly FailWindowView _view;

        public FailWindowController(FailWindowView view) : base(view)
        {
            _view = view;
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.SubscribeButtons(OnRetryButtonClick, OnNoTryButtonClick);
        }

        private void OnNoTryButtonClick()
        {
        }

        private void OnRetryButtonClick()
        {
        }
    }
}
