using System;
using UnityEngine;

namespace PlayerLogics.Animations
{
    public class PlayerAnimationTriggetHelper : MonoBehaviour
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