using UnityEngine;
public class AnimationTrigger : MonoBehaviour
{
   internal static bool _animationPlay = false;

   public void OnAnimationStart()
   {
      _animationPlay = true;
   }
   
   public void OnAnimationTrigger()
   {
      _animationPlay = false;
   }
}
