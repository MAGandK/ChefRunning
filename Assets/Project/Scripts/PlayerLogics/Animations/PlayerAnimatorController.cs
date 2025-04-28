using UnityEngine;

namespace PlayerLogics
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] public Animator _animator;

        private readonly int Run = Animator.StringToHash("IsRun");
        private readonly int Died = Animator.StringToHash("Died");
        private readonly int Dance = Animator.StringToHash("Danced");
        private readonly int Hit = Animator.StringToHash("IsHit");

        public void Running()
        {
            if (!_animator.GetBool(Died))
            {
                _animator.SetBool(Run, true);
                _animator.SetBool(Died, false);
                _animator.SetBool(Dance, false);
            }
        }

        public void StopRun()
        {
            _animator.SetBool(Run, false);
        }

        public void Dying()
        {
            StopRun();
            _animator.SetTrigger(Died);
        }

        public void Danced()
        {
            StopRun();
            _animator.SetTrigger(Dance);
            _animator.SetBool(Dance, true);
        }

        public void Hitting()
        {
            _animator.SetTrigger(Hit);
        }

        public void ResetAnimation()
        {
            _animator.SetBool(Run, false);
            _animator.SetBool(Died, false);
            _animator.SetBool(Dance, false);
            _animator.ResetTrigger(Died);
            _animator.ResetTrigger(Dance);
            _animator.ResetTrigger(Hit);
        }
    }
}