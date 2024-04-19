using DungeonRPG.Scripts.Helper;
using Godot;
using Godot.Collections;
using System;

public partial class EnemyPatrolState : EnemyStateMachine
{
    private int _currentWaypointIndex;

    // Timer Settings------------------------------------------------------------------------------

    [ExportGroup("Timer settings")]
    [Export]
    private Timer _waitTimer;

    [Export(PropertyHint.Range, "0,20,0.1")]
    private float _maxWaitTime;

    private RandomNumberGenerator _rng;

    //---------------------------------------------------------------------------------------------


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (!_waitTimer.IsStopped())
        {
            return;
        }

        MoveToDestination();
    }


    protected override void EnterCurrentState()
    {
        _rng = new RandomNumberGenerator();
        _enemyNode.NavAgent.NavigationFinished += HandleSettingTheNextaypoint;
        _waitTimer.Timeout += HandleWaitTimerTimeout;
        _enemyNode.DetectionArea.BodyEntered += HandleChaseArea;

        _currentWaypointIndex = 1;

        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        
        // Get the next waypoint and set it as the target destination
        _destination = GetNextWaypoint(_currentWaypointIndex);
        _enemyNode.NavAgent.TargetPosition = _destination;
    }


    protected override void ExitCurrentState()
    {
        base.ExitCurrentState();
        _enemyNode.NavAgent.NavigationFinished -= HandleSettingTheNextaypoint;
        _waitTimer.Timeout -= HandleWaitTimerTimeout;
        _enemyNode.DetectionArea.BodyEntered -= HandleChaseArea;
    }


    /// <summary>
    /// Set the wait timer and play idle animation and when the timer runs out set the next waypoint
    /// </summary>
    private void HandleSettingTheNextaypoint()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.IDLE);

        _maxWaitTime = _rng.RandfRange(0, _maxWaitTime);
        _waitTimer.WaitTime = _maxWaitTime;
        _waitTimer.Start();
    }


    private void HandleWaitTimerTimeout()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);

        _currentWaypointIndex = Mathf.Wrap(++_currentWaypointIndex, 0, _enemyNode.PathNode.Curve.PointCount);
        _destination = GetNextWaypoint(_currentWaypointIndex);

        GD.Print("waypoint index: " + _currentWaypointIndex);
        GD.Print($"Timer state: {_waitTimer.IsStopped()}");

        // _destination = GetNextWaypoint(_currentWaypointIndex);
        // _enemyNode.NavAgent.TargetPosition = _destination;

        // MoveToDestination();
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
