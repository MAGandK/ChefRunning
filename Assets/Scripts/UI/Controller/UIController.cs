using System.Collections.Generic;
using System.Linq;
using UI.Popups;
using UI.Window.StartWindow;
using UnityEngine;

namespace UI
{
    public class UIController : IUIController
    {
        private readonly IEnumerable<IWindowController> _controllers;
        private List<IWindowController> _openedWindows = new();

        public UIController(IEnumerable<IWindowController> controllers)
        {
            _controllers = controllers;

            foreach (var windowController in _controllers)
            {
                windowController.SetUIController(this);
                windowController.Hide();
            }

            ShowWindow<StartWindowController>();
        }

        public void ShowWindow<T>() where T : IWindowController
        {
            var window = _controllers.FirstOrDefault(x => x is T);

            if (window == null || (_openedWindows.Count > 0 && window == _openedWindows[^1]))
            {
                Debug.LogError("");
                return;
            }

            if (window is not IPopupController popupController)
            {
                foreach (var openedWindow in _openedWindows)
                {
                    openedWindow.Hide();
                }
            }

            _openedWindows.Add(window);
            window.Show();
        }

        public T GetWindow<T>() where T : class, IWindowController
        {
            return _controllers.FirstOrDefault(x => x is T) as T;
        }

        public void CloseLastOpenPopup()
        {
            var windowController = _openedWindows[^1];
            if (windowController is not IPopupController)
            {
                return;
            }

            windowController.Hide();
            _openedWindows.Remove(windowController);
        }
    }
}