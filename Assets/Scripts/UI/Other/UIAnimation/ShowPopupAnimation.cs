using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Other.UIAnimation
{
    public class ShowPopupAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _contentBack;
        [SerializeField] private float _scaleDownValue = 0.9f;
        [SerializeField] private float _scaleDuration = 0.2f;
        [SerializeField] private Image _back;
        
        [SerializeField] private RectTransform _rotateIcon;
        [SerializeField] private RectTransform _rotateIconVibration;
        [SerializeField] private Vector3 _rotateValue = new Vector3(0, 0, 5);
        [SerializeField] private float _rotateDuration = 0.2f;
        
        [SerializeField] private RectTransform _shakeIcon;
        [SerializeField] private float _shakeDuration = 0.4f;
        [SerializeField] private float _shakeValue = 0.9f;
        [SerializeField] private Vector2 _shakeStrength;
        public void Play()
        {
            if (_contentBack != null)
            {
                PlayBackScaleAnimation();
            }

            if (_back != null)
            {
                PlayFadeAnimation();
            }

            if (_rotateIcon != null)
            {
                PlayRotateAnimation(_rotateIcon);
            }

            if (_rotateIconVibration != null)
            {
                PlayRotateAnimation(_rotateIconVibration);
            }

            if (_shakeIcon != null)
            {
                PlayShakeAnimation();
            }
        }

        private void PlayFadeAnimation()
        {
            var colorAlfa = _back.color.a;
            _back.color = new Color(_back.color.r, _back.color.g, _back.color.b, 0);

            _back.DOFade(colorAlfa, _scaleDuration).Play();
        }

        private void PlayBackScaleAnimation()
        {
            var startLocalScale = _contentBack.localScale;

            var sequence = DOTween.Sequence();

            var scaleDuration = _scaleDuration / 3;

            var tween = _contentBack.DOScale(startLocalScale * _scaleDownValue, scaleDuration);
            sequence.Append(tween);
            
            tween = _contentBack.DOScale(startLocalScale, scaleDuration * 2);
            sequence.Append(tween);
            
            sequence.Play();
        }

        private void PlayRotateAnimation(RectTransform rect)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(rect.DORotate(_rotateValue, _rotateDuration / 2));
            sequence.Append(rect.DORotate(-_rotateValue, _rotateDuration));
            sequence.Append(rect.DORotate(Vector3.zero, _rotateDuration / 2));
            sequence.SetLoops(-1, LoopType.Restart);
        }

        private void PlayShakeAnimation()
        {
            _shakeIcon.DOShakePosition(
                duration: _shakeDuration,
                strength: _shakeStrength,
                vibrato: 50,
                randomness: 90,
                snapping: false,
                fadeOut: true
            );
        }
    }
}
