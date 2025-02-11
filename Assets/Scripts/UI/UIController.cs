using UI.Window;
using UI.Window.StartWindow;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private WindowBase[] _windows;
        
        private void Awake()
        {
            _windows = GetComponentsInChildren<WindowBase>(true);
            
           ShowWindow<StartWindow>();
        }

        public void ShowWindow<T>() where T : WindowBase
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                if (_windows[i] is T)
                {
                    _windows[i].ShowWindow();
                }
                else
                {
                    _windows[i].CloseWindow();
                }
            }
        }

        public T GetWindow<T>() where T : WindowBase
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                if (_windows[i] is T result)
                {
                    return result;
                }
            }

            return null;
        }
    }
}