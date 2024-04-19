using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyIdleState : EnemyStateMachine
{
    protected override void EnterCurrentState()
    {
        _enemyNode.DetectionArea.BodyEntered += HandleChaseArea;
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.IDLE);
    }

    protected override void ExitCurrentState()
    {
        _enemyNode.DetectionArea.BodyEntered -= HandleChaseArea;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        _enemyNode.StateMachine.SwitchState<EnemyReturnState>();
    }
}
