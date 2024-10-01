using Zenject;

public class FinishWindow : WindowBase
{
    private LevelPrefabManager _levelPrefab;

    [Inject]
    private void Construct(LevelPrefabManager levelPrefabManager)
    {
        _levelPrefab = levelPrefabManager;

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
        _levelPrefab.LoadScene();
    }
}
