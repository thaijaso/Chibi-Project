using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(
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

        if (!player.PlayerInput.IsMoving && !player.PlayerInput.IsAiming && !player.PlayerMovement.IsAirborne())
        {
            // Transition to Idle State if no input is detected
            stateMachine.SetState(player.idle);
        }

        if (CanJump())
        {
            stateMachine.SetState(player.jump);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // Shared movement logic
        Vector3 direction = player.PlayerInput.GetMovementDirection();
        player.PlayerMovement.Move(direction);
    }
    public bool CanJump()
    {
        return player.PlayerInput.IsJumping && player.PlayerMovement.IsGrounded;
    }
}
