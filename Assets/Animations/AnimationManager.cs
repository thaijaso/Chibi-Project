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
        animator.Play(animationName, 0, 0f);
    }

    public void StopAnimation()
    {
        animator.StopPlayback();
    }

    public bool IsAnimationPlaying(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime < 1.0f;
    }
}
   