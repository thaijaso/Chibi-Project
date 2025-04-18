using UnityEngine;

public class RunState : MoveState
{
    public RunState(
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

        if (player.PlayerInput.IsAiming)
        {
            // Transition to Aim State if aiming
            stateMachine.SetState(player.aim);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        // Handle player movement
        Vector3 direction = player.PlayerInput.GetMovementDirection();
        player.PlayerMovement.Move(direction);
    }
}
