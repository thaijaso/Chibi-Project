using UnityEngine;   

public class AnimationManager
{
    private Animator animator;

    public AnimationManager(Animator animator)
    {
        this.animator = animator;
    }

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void StopAnimation()
    {
        animator.StopPlayback();
    }
}
   