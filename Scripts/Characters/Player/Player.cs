using Godot;
using System;
using DungeonRPG.Scripts.Helper;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    private AnimationPlayer _animationPlayer;

    [Export]
    private Sprite3D _sprite3D;

    [Export]
    public StateMachine StateMachine { get; private set; }

    //----------------------------------------------------------------------------------------

    private float _speed = 5.0f;
    private Vector2 _inputVector = Vector2.Zero;
    private Vector3 _movmentDirection = Vector3.Zero;

    private bool _isDashing = false;


    //-----------------------------------------------------------------------------------------
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        MovePlayer();
    }


    public override void _Input(InputEvent @event)
    {
        _inputVector = Input.GetVector(
            negativeX: InputConsts.MOVE_LEFT,
            positiveX: InputConsts.MOVE_RIGHT,
            negativeY: InputConsts.MOVE_DOWN,
            positiveY: InputConsts.MOVE_UP
        );

        if (Input.IsActionJustPressed(InputConsts.DASH))
        {
            _isDashing = true;
        }
    }

    // User Methods---------------------------------------------------------------------------------

    /// <summary>
    /// Apply the movment direction and move the player accordingly
    /// </summary>
    private void MovePlayer()
    {
        _movmentDirection = new Vector3(_inputVector.X, 0.0f, -1 * _inputVector.Y);
        Velocity = _movmentDirection * _speed;

        MoveAndSlide();
        Flip();
    }



    /// <summary>
    /// Flip the player sprite according to the moving direction
    /// </summary>
    private void Flip()
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

    /// <summary>
    /// Reference to the input vector
    /// </summary>
    public Vector2 InputVector { get => _inputVector; }

    /// <summary>
    /// Reference to the player dashing stats
    /// </summary>
    public bool IsDashing { get => _isDashing; }
}
