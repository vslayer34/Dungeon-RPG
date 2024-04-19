using Godot;
using System;

public partial class EnemyKnight : Character
{
    [Export]
    protected Path3D _pathNode;

    [Export]
    protected NavigationAgent3D _navigationAgent;

    [Export]
    protected Area3D _detectionArea;
    
    
    // Getters and Setters-------------------------------------------------------------------------

    /// <summary>
    /// Getter for the path Node
    /// </summary>
    public Path3D PathNode { get => _pathNode; }


    /// <summary>
    /// Getter for the navigation agent
    /// </summary>
    public NavigationAgent3D NavAgent { get => _navigationAgent; }


    /// <summary>
    /// Getter for the navigation agent
    /// </summary>
    public Area3D DetectionArea { get => _detectionArea; }
}
