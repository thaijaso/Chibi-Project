using UnityEngine;

public class ForwardStrafe : StrafeState
{
    public ForwardStrafe(
        Player player,
        PlayerStateMachine stateMachine,
        AnimationManager animationManager,
        string animationName
    ) : base(
        player,
        stateMachine,
        animationManager,
        animationName
    )
    { }
}
