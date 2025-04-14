using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.run);
        }
        
        if (player.PlayerInput.IsJumping && player.PlayerMovement.IsGrounded)
        {
            stateMachine.SetState(player.jump);
        }

        if (player.PlayerInput.IsAiming)
        {
            stateMachine.SetState(player.aim);
        }
    }
}
