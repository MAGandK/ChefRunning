using LevelLogic;
using PlayerLogics;
using UnityEngine;
using Zenject;

namespace Environment
{
    public class TriggerFinish : MonoBehaviour
    {
        private ILevelModel _levelModel;

        [Inject]
        private void Construct(ILevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Player player))
            {
                return;
            }
            
            _levelModel.SetState(LevelState.Win);
        }
    }
}