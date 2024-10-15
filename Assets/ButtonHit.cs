using UnityEngine;
using Zenject;

public class ButtonHit : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnHitButtonPressed();
        }
    }

    public void OnHitButtonPressed()
    {
        _gameManager.PlayerHit();  
    }
}
