using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    
    public int Run = Animator.StringToHash("IsRun");

    public int Died = Animator.StringToHash("Died");
    public int Dance = Animator.StringToHash("Danced");
    public int Hit = Animator.StringToHash("IsHit");
    public int Hits = Animator.StringToHash("IsHits");

    private void OnEnable()
    {
        GameManager.IsPlayerDie += Dying;
        GameManager.IsFinishGame += Danced;
        GameManager.IsStartGame += Running;
    }
    
    public void Running()
    {
        _animator.SetBool(Run, true);
        
    }
    
    public void StopRun()
    {
        _animator.SetBool(Run, false);
    }

    public void Dying()
    {
        _animator.SetTrigger(Died);
    }

    public void Danced()
    {
        _animator.SetTrigger(Dance);
        StopRun();
    }

    public void Hitting()
    {
        _animator.SetTrigger(Hit);
        _animator.SetInteger(Hits, Random.Range(0, 2));
    }
    
    private void OnDisable()
    {
        GameManager.IsPlayerDie -= Dying;
        GameManager.IsFinishGame -= Danced;
        GameManager.IsStartGame -= Running;
    }
}
