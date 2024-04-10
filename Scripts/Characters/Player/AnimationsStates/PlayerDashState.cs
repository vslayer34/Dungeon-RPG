using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (!_playerNode.IsDashing)
        {
            // Switch the animation to idle when the dash is finished
            _playerNode.StateMachine.SwitchState<PlayerIdleState>();
        }
    }


    protected override void EnterCurrentState()
    {
        base.EnterCurrentState();
        _playerNode.AnimationPlayer.Play(PlayerAnimationConsts.DASH);
    }
}
