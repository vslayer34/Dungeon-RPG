using Godot;
using System;

public partial class EnemyKnight : Character
{
    [Export]
    protected Path3D _pathNode;

    [Export]
    protected NavigationAgent3D _navigationAgent;    
    
    
    // Getters and Setters-------------------------------------------------------------------------

    /// <summary>
    /// Getter fo the path Node
    /// </summary>
    public Path3D PathNode { get => _pathNode; }


    /// <summary>
    /// Getter fo the navigation agent
    /// </summary>
    public NavigationAgent3D NavAgent { get => _navigationAgent; }
}
