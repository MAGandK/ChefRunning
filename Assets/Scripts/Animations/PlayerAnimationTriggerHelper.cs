using System;
using UnityEngine;

namespace Animations
{
    public class PlayerAnimationTriggerHelper : MonoBehaviour
    {
        public event Action PunchStarted;
        public event Action PunchEnded;
        
        private void StartPunch()
        {
            PunchStarted?.Invoke();
        }

        private void EndPunch()
        {
            PunchEnded?.Invoke();
        }
    }
}