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

        MoveToDestination();
    }


    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);

        _enemyNode.NavAgent.TargetPosition = _destination;
    }
}
