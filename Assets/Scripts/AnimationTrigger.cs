using System;
using UnityEngine;
public class AnimationTrigger : MonoBehaviour
{
   internal static bool _animationPlay = false;
   public static event Action AnimationEndHandler;
   
   public void OnAnimationStart()
   {
      _animationPlay = true;
   }
   
   public void OnAnimationTrigger()
   {
      AnimationEndHandler?.Invoke();
      _animationPlay = false;
   }
}
