using System;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    internal static bool _isAnimationPlay = false;
    public static event Action AnimationEndHandler;

    public void OnAnimationStart()
    {
        _isAnimationPlay = true;
    }

    public void OnAnimationTrigger()
    {
        AnimationEndHandler?.Invoke();
        _isAnimationPlay = false;
    }
}