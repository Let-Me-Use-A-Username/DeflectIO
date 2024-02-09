using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerState : State
{
    //Player state needs to be aware of player variables 
    // Such variables include : The player
    // Stats such as speed, health, direction , etc
    public RigidBody3D player;
	public StateMachine stateMachine;

	public override void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachine;
		}

        if (player == null)
        {
            player = stateMachine.targetEntity as RigidBody3D;
        }
	}

	public new void Process(double delta)
	{
	}

	public new void PhysicsProcess(double delta)
	{
	}

	public new void UnhandledInput(InputEvent @event)
	{
	}

	public new void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
	}

	public new void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
