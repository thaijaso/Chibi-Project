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
        Debug.Log("Entering Idle State");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Idle State");
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
            Debug.Log("Jumping from Idle State");
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.jumpState);
        }
    }
}
