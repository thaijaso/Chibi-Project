using UnityEngine;

public class StrafeState : PlayerState
{
    public StrafeState(
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

        if (player.PlayerInput.IsAiming && !player.PlayerInput.IsMoving)
        {
            // Transition to Aim State if only aiming
            stateMachine.SetState(player.aim);
        }

        if (!player.PlayerInput.IsAiming && player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.run);
        }

        if (player.PlayerInput.IsAiming && player.PlayerInput.IsMoving)
        {
            Vector3 inputDirection = player.PlayerInput.GetMovementDirection();
            if (inputDirection == Vector3.forward)
            {
                stateMachine.SetState(player.forwardStrafe);
            }
            else if (inputDirection == Vector3.back)
            {
                stateMachine.SetState(player.backStrafe);
            }
            else if (inputDirection == Vector3.left)
            {
                stateMachine.SetState(player.leftStrafe);
            }
            else if (inputDirection == Vector3.right)
            {
                stateMachine.SetState(player.rightStrafe);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (player.PlayerInput.IsAiming && player.PlayerInput.IsMoving)
        {
            Vector3 direction = player.PlayerInput.GetMovementDirection();
            player.PlayerMovement.Strafe(direction);
        }
    }
}

    

