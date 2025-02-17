using System.Collections.Generic;
using System.Linq;
using UI.Window;
using UI.Window.StartWindow;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIController : IUIController, IInitializable
    {
        private readonly IEnumerable<IWindowController> _controllers;

        private IWindowController _currentWindow;

        public UIController(IEnumerable<IWindowController> controllers)
        {
            _controllers = controllers;
        }

        public void Initialize()
        {
            foreach (var windowController in _controllers)
            {
                windowController.SetUIController(this);
            }

            ShowWindow<StartWindowController>();
        }

        public void ShowWindow<T>() where T : IWindowController
        {
            var windowController = _controllers.FirstOrDefault(x => x is T);

            if (windowController == null)
            {
                Debug.Log($"{typeof(T)} no found");

                return;
            }

            _currentWindow?.Hide();
            _currentWindow = windowController;
            _currentWindow.Show();
        }

        //TODO: Remove
        public T GetWindow<T>() where T : class, IWindowController
        {
            return _controllers.FirstOrDefault(x => x is T) as T;
        }
    }
}
