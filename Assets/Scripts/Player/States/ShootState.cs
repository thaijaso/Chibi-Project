using UnityEngine;

public class ShootState : PlayerState
{
    public ShootState(
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

        if (!animationManager.IsAnimationPlaying(animationName) && player.PlayerInput.IsAiming)
        {
            stateMachine.SetState(player.aimState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
