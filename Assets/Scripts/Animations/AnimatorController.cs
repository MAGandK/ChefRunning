using UnityEngine;
using Zenject;

public class AnimatorController : MonoBehaviour
{
    private int Run = Animator.StringToHash("IsRun");
    private int Died = Animator.StringToHash("Died");
    private int Dance = Animator.StringToHash("Danced");
    private int Hit = Animator.StringToHash("IsHit");
    
    [SerializeField] public Animator _animator;
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    private void OnEnable()
    {
        _gameManager .OnFinishGame += Danced;
        _gameManager .OnStartGame += Running;
        _gameManager .OnRestartGame += ResetAnimation;
    }
    
    private void OnDisable()
    {
        _gameManager .OnFinishGame -= Danced;
        _gameManager .OnStartGame -= Running;
        _gameManager .OnRestartGame -= ResetAnimation;
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