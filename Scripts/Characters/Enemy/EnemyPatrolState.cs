using DungeonRPG.Scripts.Helper;
using Godot;
using Godot.Collections;
using System;

public partial class EnemyPatrolState : EnemyStateMachine
{
    private int _currentWaypointIndex;
    protected override void EnterCurrentState()
    {
        // _enemyNode.NavAgent.LinkReached += HandleSettingTheNextaypoint;
        _enemyNode.NavAgent.NavigationFinished += HandleSettingTheNextaypoint;
        _currentWaypointIndex = 1;

        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        
        // Get the next waypoint and set it as the target destination
        _destination = GetNextWaypoint(_currentWaypointIndex);
        _enemyNode.NavAgent.TargetPosition = _destination;
    }

    private void HandleSettingTheNextaypoint()
    {
        _currentWaypointIndex = Mathf.Wrap(++_currentWaypointIndex, 0, _enemyNode.PathNode.Curve.PointCount);

        _destination = GetNextWaypoint(_currentWaypointIndex);
        _enemyNode.NavAgent.TargetPosition = _destination;
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        MoveToDestination();
    }


    // private void HandleSettingTheNextaypoint(Dictionary details)
    // {
    //     GD.Print("Called");
    //     _currentWaypointIndex = Mathf.Wrap(++_currentWaypointIndex, 0, _enemyNode.PathNode.Curve.PointCount);
    //     GD.Print(_currentWaypointIndex);

    //     _destination = GetNextWaypoint(_currentWaypointIndex);
    //     _enemyNode.NavAgent.TargetPosition = _destination;
    // }
}
