using Zenject;

public class FinishWindow : WindowBase
{
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager; 

    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
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
        gameObject.SetActive(false);

        _gameManager.RestartGame(); 
        _levelPrefabManager.LoadScene(); 
    }
}
