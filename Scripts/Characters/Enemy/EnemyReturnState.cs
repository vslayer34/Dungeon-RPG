using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyReturnState : EnemyStateMachine
{
    public override void _Ready()
    {
        base._Ready();

        // _destination = new Vector3(
        //     _enemyNode.PathNode.Curve.GetPointPosition(0).X, 
        //     _enemyNode.Position.Y,
        //     _enemyNode.PathNode.Curve.GetPointPosition(0).Z);

        // _destination = _enemyNode.PathNode.Curve.GetPointPosition(0);
        // _destination = _enemyNode.PathNode.GlobalPosition + _enemyNode.PathNode.Curve.GetPointPosition(0);

        _destination = GetNextWaypoint();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (_enemyNode.NavAgent.IsNavigationFinished())
        {
            _enemyNode.StateMachine.SwitchState<EnemyPatrolState>();
            return;
        }

        MoveToDestination();
    }


    protected override void EnterCurrentState()
    {
        _enemyNode.DetectionArea.BodyEntered += HandleChaseArea;
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);

        _enemyNode.NavAgent.TargetPosition = _destination;
    }


    protected override void ExitCurrentState()
    {
        _enemyNode.DetectionArea.BodyEntered -= HandleChaseArea;
    }
}
