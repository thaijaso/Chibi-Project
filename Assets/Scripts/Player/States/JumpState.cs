using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(
        Player player, 
        PlayerStateMachine stateMachine, 
        Animator animationController, 
        string animationName
    ) : base(player, stateMachine, animationController, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering Jump State");
        player.PlayerMovement.Jump();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Jump State");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
