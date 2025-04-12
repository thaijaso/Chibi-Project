using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected Animator animationController;
    protected string animationName;

    protected bool isExitingState;
    protected bool isAnimationFinished;

    public PlayerState(Player player, PlayerStateMachine stateMachine, Animator animationController, string animationName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animationController = animationController;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        isExitingState = false;
        isAnimationFinished = false;
        animationController.SetBool(animationName, true);
    }

    public virtual void Exit()
    {
        isExitingState = true;
        animationController.SetBool(animationName, false);
        if (!isAnimationFinished) isAnimationFinished = true;
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate() 
    {
    }
}


