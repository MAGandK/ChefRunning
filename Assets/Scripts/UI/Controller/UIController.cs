using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class UIController : IUIController
    {
        private IEnumerable<IWindowController> _controllers;

        public UIController(IEnumerable<IWindowController> controllers)
        {
            _controllers = controllers;

            foreach (var windowController in _controllers)
            {
               windowController.SetUIController(this);
            }
        }

        public void ShowWindow<T>() where T : IWindowController
        {
            var windowController = _controllers.FirstOrDefault(x=> x is T);
            
            windowController.Show();
        }

        public T GetWindow<T>() where T : class, IWindowController
        {
            return _controllers.FirstOrDefault(x=> x is T) as T;
        }
    }
}