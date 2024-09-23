using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneLevel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;

    
    
    private void OnEnable()
    {
        GameManager.IsStartGame += StartGame;
    }

    private void StartGame()
    {
        StartScene(); 
        LoadScene();  
    }
    private void StartScene()
    {
        if (_listScene.Count > 0)
        {
            _listScene[0].SetActive(true); 
            Debug.Log("Стартовая сцена активирована: " + _listScene[0].name);
        }
    }

    private void LoadScene()
    {
        if (_listScene.Count > 0)
        {
            _listScene[0].SetActive(false);
        }
        int randomIndex = Random.Range(1, _listScene.Count);
        GameObject currentScene = _listScene[randomIndex];

        currentScene.SetActive(true);

        currentScene.transform.position = new Vector3(100.7371f, -279.3909f, 585.5648f);
        Debug.Log("Загружен уровень: " + currentScene.name);
    }

    private void OnDisable()
    {
        GameManager.IsStartGame -= StartGame;
    }
}
