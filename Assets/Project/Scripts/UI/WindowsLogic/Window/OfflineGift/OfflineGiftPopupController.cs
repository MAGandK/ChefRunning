
namespace UI.WindowsLogic.Window.OfflineGift
{
    public class OfflineGiftPopupController : AbstractPopupController<OfflineGiftPopupView>
    {
        private OfflineGiftPopupView _view;

        public OfflineGiftPopupController(OfflineGiftPopupView view) : base(view)
        {
            _view = view;
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