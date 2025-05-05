using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowsLogic.Window.OfflineGift
{
    public class OfflineGiftPopupView : AbstractWindowView
    {
        [SerializeField] private Button _closeButton;

        public Button CloseButton => _closeButton;
    }
}