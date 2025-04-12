using UnityEngine;

public class AimState : PlayerState
{
    public AimState(
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

        if (!player.PlayerInput.IsAiming)
        {
            stateMachine.RemoveState(this);
            stateMachine.AddState(player.idleState);
        }
    }
}
