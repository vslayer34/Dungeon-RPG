using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyPatrolState : EnemyStateMachine
{
    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        
        // Get the next waypoint and set it as the target destination
        _destination = GetNextWaypoint(1);
        _enemyNode.NavAgent.TargetPosition = _destination;
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        MoveToDestination();
    }
}
