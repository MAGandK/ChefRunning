using LevelLogic;
using PlayerLogics;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        private readonly int Failed = Animator.StringToHash("Failed");
        private readonly int Finished = Animator.StringToHash("Finished");
        private readonly int Loaded = Animator.StringToHash("Loaded");

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _failViewTransform;

        private Player _player;
        private ILevelModel _levelModel;

        public Vector3 FailViewTransform => _failViewTransform.position;

        [Inject]
        private void Construct(ILevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        private void Awake()
        {
            _levelModel.StateChanged += LevelModelOnStateChanged;
        }

        private void OnDestroy()
        {
            _levelModel.StateChanged -= LevelModelOnStateChanged;
        }

        private void LevelModelOnStateChanged(LevelState levelState)
        {
            switch (levelState)
            {
                case LevelState.Loaded:
                    _animator.SetTrigger(Loaded);
                    break;
                
                case LevelState.Start:
                    break;
                
                case LevelState.Win:
                    _animator.SetTrigger(Finished);
                    break;
                
                case LevelState.Fail:
                    _animator.SetTrigger(Failed);
                    break;
                
                case LevelState.Pause:
                    break;
            }
        }
    }
}