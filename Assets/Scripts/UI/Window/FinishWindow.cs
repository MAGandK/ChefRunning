using Zenject;

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
        get
        {
            return WindowType.FinishWindow;
        }
    }

    public void OnNextButtonClick()
    {
       _gameManager.StartGame();
    }
}
