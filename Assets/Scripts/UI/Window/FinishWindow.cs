using Managers;
using Type;
using Zenject;

namespace UI.Window
{
    public class FinishWindow : WindowBase
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override WindowType Type
        {
            get { return WindowType.FinishWindow; }
        }

        public void OnNextButtonClick()
        {
         //   if (_gameManager.IsGameFinished)
            {
                base.CloseWindow();
                _gameManager.RestartGame();
            }
        }
    }
}