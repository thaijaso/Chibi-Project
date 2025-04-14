using UnityEngine;

public class MoveAimState : MoveState
{
    public MoveAimState(
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


    }
}

    

