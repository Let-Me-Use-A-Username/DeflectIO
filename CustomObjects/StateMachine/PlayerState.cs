using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerState : Node, State
{
    public RigidBody3D player;
	public Dictionary<string, Variant> playerProperties;
	public StateMachine stateMachine;
	public Vector3 movementDirection;
	
	public override async void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachine;
		}

		await ToSignal(stateMachine, "ready");
		
        player = stateMachine.targetEntity as RigidBody3D;
		playerProperties.Add("velocity", player.LinearVelocity);
		playerProperties.Add("direction", movementDirection);
	}

	public virtual void Process(double delta)
	{
	}

	public virtual void PhysicsProcess(double delta)
	{
	}

	public virtual void UnhandledInput(InputEvent @event)
	{
	}

	public virtual void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
	}

	public virtual void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
