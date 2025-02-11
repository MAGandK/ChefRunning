using Managers;
using Zenject;

namespace UI.Window
{
    public class FailWindow : WindowBase
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void OnRestartButtonClick()
        {
            base.CloseWindow();
            _gameManager.RestartGame();
        }
    }
}