using UnityEngine;
public class AnimatorController : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    public int Run = Animator.StringToHash("IsRun");
    public int Died = Animator.StringToHash("Died");
    public int Dance = Animator.StringToHash("Danced");
    public int Hit = Animator.StringToHash("IsHit");

    private void OnEnable()
    {
        GameManager.IsPlayerDie += Dying;
        GameManager.IsFinishGame += Danced;
        GameManager.IsStartGame += Running;
       GameManager.IsRestartGame += ResetAnimation;
    }
    
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
        _animator.SetBool(Died, true);
    }

    public void Danced()
    {
        StopRun();
        _animator.SetTrigger(Dance);
        _animator.SetBool(Dance,true);
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
    
    private void OnDisable()
    {
        GameManager.IsPlayerDie -= Dying;
        GameManager.IsFinishGame -= Danced;
        GameManager.IsStartGame -= Running;
        GameManager.IsRestartGame -= ResetAnimation;
    }
}