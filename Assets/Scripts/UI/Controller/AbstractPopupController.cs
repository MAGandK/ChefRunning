using DG.Tweening;
using UI.Popups;
using UnityEngine;

namespace UI
{
    public abstract class AbstractPopupController<T> : AbstractWindowController<T>, IPopupController where T : IWindowView
    {
        [Space] private T _baseView;
        private Tweener _showTween;
        
        protected AbstractPopupController(T view) : base(view)
        {
            _baseView = view;
        }

        public void SetOrderInLayer(int order)
        {
            _baseView.SetOrderInLayer(order);
        }
    }
}