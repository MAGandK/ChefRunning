using UnityEngine;
public class TriggerFinish : MonoBehaviour
{
    public static string LevelIndex = "Level";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            GameManager.Instance.FinishGame();
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
