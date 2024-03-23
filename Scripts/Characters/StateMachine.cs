using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class StateMachine : Node
{
    [Export]
    // Determine the current State Idle at start
    private Node _currentState;

    [Export]
    // Contains reference to all the available states 
    private Node[] _states;


    public override void _Ready()
    {
        // sent notification of the current state 
        _currentState.Notification(NotificationConsts.ENTER_STATE);
    }


    /// <summary>
    /// Loop through the states array and chane the current state from the previouse to the new state<br/>
    /// Then fire a notification for the previouse state to disable and another notification for the current state to play
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void SwitchState<T>()
    {
        Node newState = new Node();

        foreach (var state in _states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState != null)
        {
            // Befor change to the new state disable the previouse one
            _currentState.Notification(NotificationConsts.EXIT_STATE);
            _currentState = newState;
            _currentState.Notification(NotificationConsts.ENTER_STATE);
        }
    }
}