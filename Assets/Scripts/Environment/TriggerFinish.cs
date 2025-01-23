using Managers;
using UnityEngine;
using Zenject;

namespace Environment
{
    public class TriggerFinish : MonoBehaviour
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            {
                _gameManager.FinishGame();
            }
        }
    }
}