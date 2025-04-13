using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected AnimationManager animationManager;
    protected string animationName;

    public PlayerState(
        Player player,
        PlayerStateMachine stateMachine,
        AnimationManager animationManager,
        string animationName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animationManager = animationManager;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        animationManager.PlayAnimation(animationName);
    }

    public virtual void Exit()
    {
        animationManager.StopAnimation();
    }

    public virtual void LogicUpdate()
    {
        // Logic to be implemented in derived classes
    }

    public virtual void PhysicsUpdate()
    {
        // Physics logic to be implemented in derived classes
    }
}


