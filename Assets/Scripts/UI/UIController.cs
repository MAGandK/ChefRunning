using Type;
using UI.Window;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private WindowBase[] _windows;
        
        private void Awake()
        {
            _windows = GetComponentsInChildren<WindowBase>(true);
        }

        public void ShowWindow(WindowType type)
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                if (_windows[i].Type == type)
                {
                    _windows[i].ShowWindow();
                }
                else
                {
                    _windows[i].CloseWindow();
                }
            }
        }

        public WindowBase GetWindow(WindowType type)
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                if (_windows[i].Type == type)
                {
                    return _windows[i];
                }
            }

            return null;
        }

        // private void OnStartGame()
        // {
        //     ShowWindow(WindowType.MainWindow);
        // }
        //
        // private void OnFinishGame()
        // {
        //     ShowWindow(WindowType.FinishWindow);
        // }
        //
        // private void OnRestartGame()
        // {
        //     ShowWindow(WindowType.MainWindow);
        // }
    }
}