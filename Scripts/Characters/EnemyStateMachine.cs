using Godot;
using System;

public partial class EnemyStateMachine : CharacterState
{
    protected EnemyKnight _enemyNode;
    protected Vector3 _destination;

    public override void _Ready()
    {
        base._Ready();

        _enemyNode = _characterNode as EnemyKnight;
    }


    /// <summary>
    /// Get the destination to the next waypoint
    /// </summary>
    /// <param name="waypointIndex">the indext of the point at the path node<c>(default = 0)</c></param>
    /// <returns>Vector3 of the next waypoint for the enemy</returns>
    protected Vector3 GetNextWaypoint(int waypointIndex = 0)
    {
        return new Vector3(
            _enemyNode.PathNode.Curve.GetPointPosition(waypointIndex).X, 
            _enemyNode.Position.Y,
            _enemyNode.PathNode.Curve.GetPointPosition(waypointIndex).Z
        );
    }


    /// <summary>
    /// Move the enemy to the waypoint position
    /// </summary>
    protected void MoveToDestination()
    {
        _enemyNode.NavAgent.GetNextPathPosition();
        _enemyNode.Velocity = _enemyNode.GlobalPosition.DirectionTo(_destination);

        _enemyNode.MoveAndSlide();
    }
}
