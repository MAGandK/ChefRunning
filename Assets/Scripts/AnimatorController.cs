using UnityEngine;
public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    
    private string RunAnimationKey = "IsRun";
    private string DiedAnimationKey = "Died";
    private string DancedAnimationKey = "Danced";
    private string HitAnimationKey = "IsHit";
    private string HitAnimationKeys = "IsHits";
    
    public void Run()
    {
        _animator.SetBool(RunAnimationKey, true);
    }
    
    public void StopRun()
    {
        _animator.SetBool(RunAnimationKey, false);
    }

    public void Died()
    {
        _animator.SetTrigger(DiedAnimationKey);
    }

    public void Danced()
    {
        _animator.SetTrigger(DancedAnimationKey);
    }

    public void Hit()
    {
        _animator.SetTrigger(HitAnimationKey);
        _animator.SetInteger(HitAnimationKeys, Random.Range(0, 2));
    }
}
