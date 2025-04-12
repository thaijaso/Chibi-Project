using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.PlayerInput.IsMoving)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.moveState);
        }
        
        if (player.PlayerInput.IsJumping && player.PlayerMovement.IsGrounded)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.jumpState);
        }

        if (player.PlayerInput.IsAiming)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.aimState);
        }
    }
}
