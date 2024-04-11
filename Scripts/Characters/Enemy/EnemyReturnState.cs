using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyReturnState : EnemyStateMachine
{
    private Vector3 _destination;

    public override void _Ready()
    {
        base._Ready();

        // _destination = new Vector3(
        //     _enemyNode.PathNode.Curve.GetPointPosition(0).X, 
        //     _enemyNode.Position.Y,
        //     _enemyNode.PathNode.Curve.GetPointPosition(0).Z);

        // _destination = _enemyNode.PathNode.Curve.GetPointPosition(0);
        _destination = _enemyNode.PathNode.GlobalPosition + _enemyNode.PathNode.Curve.GetPointPosition(0);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        MoveToDestination();
    }


    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        // _enemyNode.Position = _destination;
    }


    /// <summary>
    /// MOve the enemy to the waypoint position
    /// </summary>
    private void MoveToDestination()
    {
        if (_enemyNode.Position == _destination)
        {
            GD.Print("Reached final destination");
            return;
        }

        GD.Print(_destination);
        _enemyNode.Velocity = _enemyNode.Position.DirectionTo(_destination);

        _enemyNode.MoveAndSlide();
    }
}
