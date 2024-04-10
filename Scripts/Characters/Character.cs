using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    protected AnimationPlayer _animationPlayer;

    [Export]
    protected Sprite3D _sprite3D;

    [Export]
    public StateMachine StateMachine { get; protected set; }

    protected Vector3 _movmentDirection = Vector3.Zero;


    /// <summary>
    /// Flip the player sprite according to the moving direction
    /// </summary>
    protected void Flip()
    {
        if (Velocity.X == 0)
        {
            return;
        }
        
        _sprite3D.FlipH = Velocity.X < 0;
    }


    // Getters and Setters----------------------------------------------------------------------------------
    
    /// <summary>
    /// Reference to the AnimationPlayer Node
    /// </summary>
    public AnimationPlayer AnimationPlayer { get => _animationPlayer; }
}