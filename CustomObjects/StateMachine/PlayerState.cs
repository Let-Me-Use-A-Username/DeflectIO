using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerState : State
{
    //Player state needs to be aware of player variables 
    // Such variables include : The player
    // Stats such as speed, health, direction , etc
    public Node player;
	StateMachine stateMachine;

	public override void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachine;
		}

        if (player == null)
        {
            player = Owner;
        }

        base._Ready();
	}

	public void Process(double delta)
	{
	}

	public void PhysicsProcess(double delta)
	{
	}

	public void UnhandledInput(InputEvent @event)
	{
	}

	public void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
	}

	public void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
