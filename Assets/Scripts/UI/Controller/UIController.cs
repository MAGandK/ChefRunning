using System.Collections.Generic;
using System.Linq;
using UI.Window.StartWindow;
using UnityEngine;

namespace UI
{
    public class UIController : IUIController
    {
        private IEnumerable<IWindowController> _controllers;

        private IWindowController _currentWindow;

        public UIController(IEnumerable<IWindowController> controllers)
        {
            _controllers = controllers;

            foreach (var windowController in _controllers)
            {
                windowController.SetUIController(this);
            }

            ShowWindow<StartWindowController>();
        }

        public void ShowWindow<T>() where T : IWindowController
        {
            _currentWindow?.Hide();
            _currentWindow = _controllers.FirstOrDefault(x => x is T);
            _currentWindow?.Show();
        }

        public T GetWindow<T>() where T : class, IWindowController
        {
            return _controllers.FirstOrDefault(x => x is T) as T;
        }
    }
}