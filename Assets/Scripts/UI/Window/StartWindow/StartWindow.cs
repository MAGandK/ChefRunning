using Type;
using UI.Window.StartWindow.Elements;
using UnityEngine;

namespace UI.Window.StartWindow
{
    public class StartWindow : WindowBase
    {
        [SerializeField] private LevelProgressBar _levelProgressBar;

        [SerializeField] private int _currentLevelIndex;
        public override WindowType Type => WindowType.StartWindow;
        

        public override void ShowWindow()
        {
            base.ShowWindow();

          //  var currentLevel = 0;
            
            _levelProgressBar.Setup(_currentLevelIndex);
        } 
    }
}
