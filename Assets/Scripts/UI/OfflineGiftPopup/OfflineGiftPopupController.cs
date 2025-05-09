namespace UI.OfflineGiftPopup
{
    public class OfflineGiftPopupController: AbstractPopupController<OfflineGiftPopupView>
    {
        private readonly OfflineGiftPopupView _view;
        
        public OfflineGiftPopupController(OfflineGiftPopupView view) : base(view)
        {
            _view = view;
        }

        protected override void OnShow()
        {
            base.OnShow();
            _view.ShowPopupAnimation.Play();
        }

        public override void Initialize()
        {
            base.Initialize();
            _view.CloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
           _uiController.CloseLastOpenPopup();
        }
    }
}