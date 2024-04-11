using Godot;
using System;

public partial class EnemyKnight : Character
{
    [Export]
    protected Path3D _pathNode;

    
    
    
    // Getters and Setters-------------------------------------------------------------------------

    /// <summary>
    /// Getter fo the path Node
    /// </summary>
    public Path3D PathNode { get => _pathNode; }
}
