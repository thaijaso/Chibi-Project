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
        player.PlayerMovement.Jump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.PlayerMovement.IsGrounded && player.PlayerMovement.PlayerRigidbody.linearVelocity.y <= 0)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
