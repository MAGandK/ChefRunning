using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window
{
    public class FailWindow : MonoBehaviour
    {
        public event Action RetryButtonPressed;
        public event Action NoTryButtonPressed;
        
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _noTryButton;
        private void Awake()
        {
           _retryButton.onClick.AddListener(OnRetryButtonClick);
           _noTryButton.onClick.AddListener(OnNoTryButtonClick);
        }

        private void OnNoTryButtonClick()
        {
            NoTryButtonPressed?.Invoke();
        }

        private void OnRetryButtonClick()
        {
            RetryButtonPressed?.Invoke();
        }
    }
}