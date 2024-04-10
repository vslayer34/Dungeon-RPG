using Godot;
using System;
using DungeonRPG.Scripts.Helper;

public partial class Player : Character
{
    [Export(PropertyHint.Range, "0, 10, 0.1")]
    private float _speed = 5.0f;
    private Vector2 _inputVector = Vector2.Zero;

    //Dash Config------------------------------------------------------------------------------

    private bool _isDashing = false;
    
    [Export(PropertyHint.Range, "0, 20, 0.1")]
    private float _dashSpeed = 10.0f;
    
    // The last input when the player pressed dash
    private Vector3 _dashDirection;


    //-----------------------------------------------------------------------------------------

    public override void _Ready()
    {
        _dashTimer.Timeout += HandleDashTimeOut;
    }



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
            // Enter dash state and set its direction
            // if the player is movineg get last move
            if (_inputVector != Vector2.Zero)
            {
                _dashDirection = new Vector3(_inputVector.X, 0.0f, -_inputVector.Y);
            }
            // if player is stationiory get the direction according to sprite orientation
            else
            {
                _dashDirection = _sprite3D.FlipH ? Vector3.Left : Vector3.Right;
            }
            _isDashing = true;
            _dashTimer.Start();
        }
    }

    // User Methods---------------------------------------------------------------------------------

    /// <summary>
    /// Apply the movment direction and move the player accordingly
    /// </summary>
    private void MovePlayer()
    {
        _movmentDirection = new Vector3(_inputVector.X, 0.0f, -1 * _inputVector.Y);

        // Prevent the player from moving when he/she is dashing
        Velocity = _isDashing ? _dashDirection * _dashSpeed : _movmentDirection * _speed;



        MoveAndSlide();
        Flip();
    }


    /// <summary>
    /// return the player from the dash state
    /// </summary>
    private void HandleDashTimeOut()
    {
        _isDashing = false;
    }


    // Getters and Setters----------------------------------------------------------------------------------

    /// <summary>
    /// Reference to the input vector
    /// </summary>
    public Vector2 InputVector { get => _inputVector; }
    

    /// <summary>
    /// Reference to the player dashing stats
    /// </summary>
    public bool IsDashing { get => _isDashing; }
}
