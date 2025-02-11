using Managers;
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

        public void OnNextButtonClick()
        {
            base.CloseWindow();
            _gameManager.RestartGame();
        }
    }
}