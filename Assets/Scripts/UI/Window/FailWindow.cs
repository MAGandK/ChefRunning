using Zenject;

public class FailWindow : WindowBase
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public override WindowType Type
    {
        get { return WindowType.FailWindow; }
    }

    public void OnRestartButtonClick()
    {
        base.CloseWindow();
        _gameManager.RestartGame();
    }
}