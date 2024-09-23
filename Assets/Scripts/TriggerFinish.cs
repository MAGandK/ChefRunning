using UnityEngine;
using Zenject;

public class TriggerFinish : MonoBehaviour
{
    public static string LevelIndex = "Level";

    private GameManager _gameManager;
    private Player _player;
    

    [Inject]
    private void Construct(GameManager gameManager, Player player)
    {
        _gameManager = gameManager;
        _player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _gameManager.FinishGame();
            Debug.Log("Finish");
            OnFinished();
        }
    }
    private void OnFinished()
    {
        // var levelIndex = PlayerPrefs.GetInt(StartUp.LevelKey);
        //
        // levelIndex++;
        //
        // PlayerPrefs.SetInt(StartUp.LevelKey, levelIndex);

        // var sceneName = SettingManager.Instance.LevelSettings.GetSceneName(levelIndex);
        //
        // SceneManager.LoadScene(sceneName);
    }
}
