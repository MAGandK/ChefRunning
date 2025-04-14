using System.Collections;
using Managers;
using UI;
using UI.Window;
using UI.Window.GameWindow;
using UnityEngine;
using Zenject;

namespace Obstacle
{
    public class Coin : MonoBehaviour
    {
        private float _rotationSpeed = 200f;
        public float _rotationDelay = 0f;
        private IUIController _uiController;
       // private LevelPrefabManager _levelPrefabManager;
       // private AudioManager _audioManager;

        [Inject]
        public void Construct(IUIController uiController)
        {
            _uiController = uiController;
           // _levelPrefabManager = levelPrefabManager;
            //_audioManager = audioManager;
        }

        private void OnEnable()
        {
            StartCoroutine(StartRotationWithDelay());
        }

        private void Start()
        {
            StartCoroutine(StartRotationWithDelay());
        }

        private IEnumerator StartRotationWithDelay()
        {
            yield return new WaitForSeconds(_rotationDelay);

            while (true)
            {
                transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            CollectCoin();
           // _levelPrefabManager._coinsList.Add(gameObject);
            gameObject.SetActive(false);
        }

        private void CollectCoin()
        {
            //  var mainWindow = _uiController.GetWindow<>();
            //  if (mainWindow != null)
            //  {
            //      mainWindow.OnCoinCollected();
            //  }
            //
            // _audioManager.PlaySound(SoundType.Coin);
        }
    }
}