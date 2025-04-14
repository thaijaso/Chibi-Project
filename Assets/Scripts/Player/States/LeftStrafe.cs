using UnityEngine;

public class LeftStrafe : StrafeState
{
    public LeftStrafe(
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
}
