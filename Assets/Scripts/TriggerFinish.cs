using UnityEngine;
using Zenject;

public class TriggerFinish : MonoBehaviour
{
    public static string LevelIndex = "Level";

    private GameManager _gameManager;

    [Inject]
    private void Constract(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            _gameManager.FinishGame();
            Debug.Log("Finish");
            OnFinished();
        }
    }
    private void OnFinished()
    {
        var levelIndex = PlayerPrefs.GetInt(StartUp.LevelKey);
        levelIndex++;
        PlayerPrefs.SetInt(StartUp.LevelKey, levelIndex);
    }
}
