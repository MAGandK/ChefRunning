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
        GameManager.IsRestartGame += ResetAnimation;
    }
    
    public void Running()
    {
        _animator.SetBool(Run, true);
        Debug.Log("12");
    }
    
    public void StopRun()
    {
        _animator.SetBool(Run, false);
    }

    public void Dying()
    {
        _animator.SetBool(Died, true);
    }

    public void Danced()
    {
        StopRun();
        _animator.SetBool(Dance,true);
    }

    public void Hitting()
    {
        _animator.SetTrigger(Hit);
        _animator.SetInteger(Hits, Random.Range(0, 2));
    }
    
    public void ResetAnimation()
    {
        Debug.Log("Анимации обновились");
        
        _animator.SetBool(Run, false);
        _animator.SetBool(Died, false);  
        
        _animator.ResetTrigger(Died);
        _animator.ResetTrigger(Dance);
        _animator.ResetTrigger(Hit);
        
        Running();
    }


    private void OnDisable()
    {
        GameManager.IsPlayerDie -= Dying;
        GameManager.IsFinishGame -= Danced;
        GameManager.IsStartGame -= Running;
        GameManager.IsRestartGame -= ResetAnimation;
    }
}
