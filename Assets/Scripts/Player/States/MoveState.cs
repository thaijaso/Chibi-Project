using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(
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
        Debug.Log("Entering Move State");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Move State");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Transition to Idle State if no input is detected
        if (!player.PlayerInput.IsMoving)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.idleState);
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
