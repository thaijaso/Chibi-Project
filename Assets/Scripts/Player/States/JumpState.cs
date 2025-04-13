using System;
using UnityEngine;

public class JumpState : MoveState
{
    public JumpState(
        Player player, 
        PlayerStateMachine stateMachine, 
        AnimationManager animationManager, 
        string animationName
    ) : base(
        player, 
        stateMachine,
        animationManager, 
        animationName
    ) {}

    public override void Enter()
    {
        base.Enter();
        player.PlayerMovement.Jump();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.PlayerMovement.IsGrounded && !player.PlayerMovement.IsAirborne())
        {
             stateMachine.SetState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate(); 
    }
}
