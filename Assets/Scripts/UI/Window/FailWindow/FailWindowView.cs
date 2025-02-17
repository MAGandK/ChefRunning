using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Window.FailWindow
{
    public class FailWindowView : AbstractWindowView
    {
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _noTryButton;


        public void SubscribeButtons(UnityAction onRetryButtonClick, UnityAction onNoTryButtonClick)
        {
            _retryButton.onClick.AddListener(onRetryButtonClick);
            _noTryButton.onClick.AddListener(onNoTryButtonClick);
        }
    }
}
