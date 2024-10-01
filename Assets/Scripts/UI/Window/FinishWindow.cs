using UnityEngine;
using Zenject;

public class FinishWindow : WindowBase
{
    private LevelPrefabManager _sceneLevel;

    [Inject]
    private void Construct(LevelPrefabManager sceneLevel)
    {
        _sceneLevel = sceneLevel;
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
        this.gameObject.SetActive(false);
        _sceneLevel.LoadScene();
        Debug.Log("Нажата кнопка Next, загружается случайный уровень");
    }
}
