using UnityEngine;
using UnityEngine.UI;

namespace UI.OfflineGiftPopup
{
    public class OfflineGiftPopupView : AbstractWindowView
    {
        [SerializeField] private Button _closeButton;

        public Button CloseButton => _closeButton;
    }
}